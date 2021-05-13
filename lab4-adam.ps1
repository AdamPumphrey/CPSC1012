# Adam Pumphrey, DMIT1532 OA01, March 30, 2021
# Lab 4, Bart Oleksy


# https://docs.microsoft.com/en-us/powershell/scripting/learn/ps101/09-functions?view=powershell-7.1
function Display-Menu { # function for displaying the menu
    # https://social.technet.microsoft.com/Forums/windowsserver/en-US/fb79c691-a5b6-4839-b65b-b061a7bccd2e/how-do-i-create-a-string-with-repeating-characters?forum=winserverpowershell
    $equal_signs = "=" * 70
    Write-Host
    Write-Host
    Write-Host $equal_signs -ForegroundColor Cyan
    Write-Host "=" (" " * 27) "MAIN MENU" (" " * 28) "=" -ForegroundColor Cyan
    Write-Host $equal_signs -ForegroundColor Cyan
    Write-Host
    Write-Host "Choose your selection." -ForegroundColor Cyan
    Write-Host "1. Report Computer Name and the OS Version"
    Write-Host "2. Report on disk Space"
    Write-Host "3. Report on FolderSpace for Specified folder"
    Write-Host "4. Create a folder and copy all text files from a specified folder on local machine"
    Write-Host "5. Create a local user"
    Write-Host "6. Stop or Start a Service based on its display name"
    Write-Host "7. Set the IP address (on localhost only)"
    Write-Host "8. Test connectivity on a machine return True (active) or False (no response)"
    Write-Host "9. Exit"
    Write-host
    $selection= Read-Host "Select 1-9"
    return $selection  # return the user's choice
}

function Selection_Error { # function for displaying invalid input error message
    Write-Host
    Write-Host "Invalid input. Please enter a number from 1-9."
    # https://stackoverflow.com/a/22362868
    Write-Host "Press any key to continue."
    [void][System.Console]::ReadKey($true)
}

function Invalid_Folder { # simple function for displaying invalid folder name
    Write-Host
    Write-Host "Invalid folder name"
}

function Local_Foldername($foldername) { # function for folder path input error checking
    if ($foldername.Length -eq 0) {
        return $false
    }

    elseif (Test-Path -Path $foldername) {
        return $true
    }

    else {
        return $false
    }
}

clear

$local_remote_status = $false
$local_remote = 0 # 1 = local, 2 = remote, 0 = error

while ($local_remote_status -eq $false) {
    Write-Host
    Write-Host "Run the script on local machine or a remote machine?"
    $machine_choice = Read-Host "Enter 1 for local machine, 2 for remote machine"

    if ($machine_choice -eq "1" -or $machine_choice -eq "2") {

        if ($machine_choice -eq "2") {
            Write-Host
            Write-Host "If you make a mistake here just restart the script, cancelling the login box does not restart script"
            Write-Host
            $machine_name = Read-Host "Enter remote machine name"

            if (Test-WSMan $machine_name -ErrorAction SilentlyContinue) { # test remote configuration
                $connected = $false

                do {
                    Write-Host
                    $credential = Read-Host "Enter user to connect with (eg. Administrator or <domain>\<account>)"
                    $session = New-PSSession -ComputerName $machine_name -Credential $credential -ErrorAction SilentlyContinue
                    if (Get-PSSession) { # check to see that session was properly created and is running
                        $connected = $true
                    }
                    else {
                        Write-Host
                        Write-Host "Error creating session. Make sure user exists, user is spelled correctly, password is correct, etc."
                    }
                }
                until ($connected)

                Write-Host
                Write-Host "Connection successful."
                $local_remote = 2 # change status to "remote"
                Write-Host "Press any key to continue."
                [void][System.Console]::ReadKey($true)
                $local_remote_status = $true
            }

            else {
                Write-Host
                Write-Host "Error with remoting. Check to see if the computer name is correctly spelled, if the computer is powered on, and if remoting is enabled"
            }
                
        }

        else {
            $local_remote_status = $true
            $local_remote = 1 # change status to "local"
        }
    }

    else {
        Write-Host
        Write-Host "Invalid input. Enter either 1 or 2"
    }
}

clear

$running = $true

while ($running -eq $true) {
    $validinput = $false

    do {
        $selection = Display-Menu
        # could not think of a cleaner way to explicitly allow selection from 1-9
        # had to get around possible decimal inputs (eg. 1.9) being accepted
        if ($selection -eq "1" -or $selection -eq "2" -or $selection -eq "3" -or $selection -eq "4" -or $selection -eq "5" -or $selection -eq "6" -or $selection -eq "7" -or $selection -eq "8" -or $selection -eq "9") {
            $selection = [int]$selection # since read-host is string, make sure selection is int
            $validinput = $true
        }
        else {
            Selection_Error
        }
    }
    until ($validinput)

    switch ($selection) {
        1 { # report computer name and OS version

            if ($local_remote -eq 1) { # if running locally
                $computersystem = Get-WmiObject Win32_ComputerSystem
                $os = Get-WmiObject Win32_OperatingSystem
            }

            elseif ($local_remote -eq 2) { # if running remotely
                $computersystem = Invoke-Command -Session $session -ScriptBlock { Get-WmiObject Win32_ComputerSystem }
                $os = Invoke-Command -Session $session -ScriptBlock { Get-WmiObject Win32_OperatingSystem }
            }

            else {
                Write-Host "Something went wrong"
            }

            Write-Host
            Write-Host "Computer name is:" $computersystem.name
            Write-Host "OS version is:" $os.version
        }

        2 { # report on disk space (c: drive)

            if ($local_remote -eq 1) { # if running locally
                $disk = Get-WmiObject Win32_LogicalDisk -Filter "DeviceID='C:'"
                # https://stackoverflow.com/a/12159479 - first comment
                $diskspace = $disk.freespace/1GB
                
            }

            elseif ($local_remote -eq 2) { # if running remotely
                Invoke-Command -Session $session -ScriptBlock { $disk = Get-WmiObject Win32_LogicalDisk -Filter "DeviceID='C:'" }
                $diskspace = Invoke-Command -Session $session -ScriptBlock { $disk.freespace/1GB }
            }

            else {
             Write-Host "Something went wrong"
            }

            Write-Host
            Write-Host "There are" $diskspace "GBs of free space in drive C:"
        }
        3 { # report on folderspace for specified folder
            $validname = $false

            do {

                if ($local_remote -eq 1) { # if running locally
                    Write-Host
                    $foldername = Read-Host "Enter a folder path (eg. c:\software)"

                    if (Local_Foldername($foldername)) { # calls function to check if folder path exists
                        $validname = $true
                        # https://docs.microsoft.com/en-us/previous-versions/windows/it-pro/windows-powershell-1.0/ff730945(v=technet.10)
                        # basically measuring the size of each item in each folder and summing the values
                        $foldersize = ((Get-ChildItem $foldername -Recurse | Measure-Object -Property Length -Sum).Sum)/1MB
                        Write-Host
                        Write-Host "Folder" $foldername "is" $foldersize "MB"
                    }

                    else { 
                        Invalid_Folder
                    }
                }

                elseif ($local_remote -eq 2) { # if running remotely
                    # needed to run read-host remotely to store folder name for remote path testing
                    # can't pass in a variable from script running on client pc to remote pc pssession
                    Write-Host
                    Invoke-Command -Session $session -ScriptBlock { $foldername = Read-Host "Enter a folder path (eg. c:\software)" }
                    $foldername = Invoke-Command -Session $session -ScriptBlock { $foldername }

                    if ($foldername.Length -eq 0) {
                        Invalid_Folder
                    }

                    elseif (Invoke-Command -Session $session -ScriptBlock { Test-Path -Path $foldername }){
                        $validname = $true
                        $foldersize = Invoke-Command -Session $session -ScriptBlock { ((Get-ChildItem $foldername -Recurse | Measure-Object -Property Length -Sum).Sum)/1MB }
                        Write-Host
                        Write-Host "Folder" $foldername "is" $foldersize "MB"
                    }

                    else {
                        Invalid_Folder
                    }
                     
                }

                else {
                    Write-Host "Something went wrong"
                }

            } until ($validname)
        }
        4 { # create a folder and copy all test files from a specified folder on local machine
            $valid_foldername = $false

            do {
                Write-Host
                $local_foldername = Read-Host "Enter the local folder's path (eg. c:\software)"

                if (Local_Foldername($local_foldername)) { # calls function to check if folder path exists
                    $valid_foldername = $true
                }

                else {
                    Invalid_Folder
                }

            } until ($valid_foldername)

            Write-Host

            $valid_destname = $false
            if ($local_remote -eq 1) { # if running locally

                do {
                    Write-Host
                    $dest_foldername = Read-Host "Enter the destination folder's path (eg. c:\software)"
                   
                    if ($dest_foldername.Length -eq 0) {
                        Invalid_Folder
                    }

                    elseif (Test-Path -Path $dest_foldername) {
                        $valid_destname = $true
                    }

                    else {
                        # redirect output to null to hide output - https://stackoverflow.com/questions/5260125/whats-the-better-cleaner-way-to-ignore-output-in-powershell
                        New-Item -Path $dest_foldername -ItemType directory > $null 
                        $valid_destname = $true
                    }

                } until ($valid_destname)

                Write-Host

                # https://ss64.com/ps/foreach-object.html - % is an alias for ForEach-Object, pretty cool
                Get-ChildItem -Path $local_foldername -Filter *.txt | % { # for each .txt file, get the full path and copy to the destination
                    $itempath = $_.FullName
                    Copy-Item $itempath -Destination $dest_foldername
                    write-host $itempath "copied to" $dest_foldername
                }
            }

            elseif ($local_remote -eq 2) { # if running remotely
                
                # same thing as local, just running commands remotely
                do {
                    Write-Host
                    Invoke-Command -Session $session -ScriptBlock { $dest_foldername = Read-Host "Enter the destination folder's path (eg. c:\software)" }
                    $dest_foldername = Invoke-Command -Session $session -ScriptBlock { $dest_foldername }

                    if ($dest_foldername.Length -eq 0) {
                        Invalid_Folder
                    }

                    elseif (Invoke-Command -Session $session -ScriptBlock { Test-Path -Path $dest_foldername }) {
                        $valid_destname = $true
                    }

                    else {
                        Invoke-Command -Session $session -ScriptBlock { New-Item -Path $dest_foldername -ItemType directory > $null }
                        $valid_destname = $true
                    }

                } until ($valid_destname)

                Write-Host

                Get-ChildItem -Path $local_foldername -Filter *.txt | % {
                    $itempath = $_.FullName
                    # https://blog.ipswitch.com/use-powershell-copy-item-cmdlet-transfer-files-winrm
                    Copy-Item $itempath -Destination $dest_foldername -ToSession $session
                    write-host $itempath "copied to" $dest_foldername "on remote machine"
                }
            }

            else {
                Write-Host "Something went wrong"
            }
        }
        5 { # create a local user
            $valid_username = $false

            do {

                if ($local_remote -eq 1) { # if running locally
                    Write-Host
                    $new_username = Read-Host "Enter a username for the new local user"

                    if ($new_username.Length -eq 0) {
                        Write-Host
                        Write-Host "Username cannot be blank"
                    }

                    else {
                        $name_exists = $false
                        $localaccounts = Get-WmiObject win32_useraccount -Filter "localaccount = true"

                        foreach ($account in $localaccounts) {

                            if ($new_username -eq $account.Name) {
                                $name_exists = $true
                                break # exit loop if user exists - no point in continuing search
                            }
                        }

                        if (-not $name_exists) { # if user does not already exist
                            $valid_username = $true
                            $password = "Password1" # using default password since it meets security policy reqs
                            NET USER $new_username $password /add > $null # create new user
                            Write-Host
                            Write-Host "User" $new_username "created with default password"
                        }

                        else {
                            Write-Host
                            Write-Host "User already exists"
                        }
                    }
                    
                }

                elseif ($local_remote -eq 2) { # if running remotely - AD user instead of local user since it is a domain controller
                    Write-Host
                    Invoke-Command -Session $session -ScriptBlock { $new_username = Read-Host "Enter a username for the new AD user" }
                    $new_username = Invoke-Command -Session $session -ScriptBlock { $new_username }

                    if ($new_username.Length -eq 0) {
                        Write-Host
                        Write-Host "Username cannot be blank"
                    }

                    else {
                        $name_exists = $false
                        Invoke-Command -Session $session -ScriptBlock { $name_found = $false }
                        # check if an AD user already exists with the entered name
                        Invoke-Command -Session $session -ScriptBlock { Get-ADUser -Filter * | % { 
                            # for each AD user, if AD user's name = entered name
                            if ($new_username -eq $_.Name) {
                                $name_found = $true
                            }
                        }}

                        $name_exists = Invoke-Command -Session $session -ScriptBlock { $name_found }

                        if (-not $name_exists) {
                            $valid_username = $true
                            # using default password
                            # need to convert to secure string since new-aduser -accountpassword only accepts secure strings
                            Invoke-Command -Session $session -ScriptBlock { $password = ConvertTo-SecureString -String "Password1" -AsPlainText -Force }
                            Invoke-Command -Session $session -ScriptBlock { New-ADUser -Name $new_username -AccountPassword $password }
                            Write-Host
                            Write-Host "AD User" $new_username "created with default password Password1"
                        }

                        else {
                            Write-Host
                            Write-Host "AD User already exists"
                        }
                    }
                }

                else {
                    Write-Host "Something went wrong"
                }

            } until ($valid_username)
        }
        6 { # stop or start a service based on its display name
            $valid_servicename = $false

            do {

                if ($local_remote -eq 1) { # if running locally
                    Write-Host
                    $servicename = Read-Host "Enter a service name"

                    # this could be a function but its too short to make a difference
                    if ($servicename.Length -eq 0) {
                        Write-Host
                        Write-Host "Invalid service name - service name cannot be empty"
                    }

                    # https://social.technet.microsoft.com/Forums/azure/en-US/8c2c8111-8995-4ff6-a25c-e0f48136e14f/determine-if-service-exists?forum=winserverpowershell
                    elseif (Get-Service $servicename -ErrorAction SilentlyContinue) {
                        $valid_servicename = $true

                        if ((Get-Service $servicename).Status -eq "Running") {
                            Write-Host
                            Write-Host "Stopping service" $servicename
                            Stop-Service $servicename
                        }

                        else {
                            Write-Host
                            Write-Host "Starting service" $servicename
                            Start-Service $servicename
                        }
                    }

                    else {
                        Write-Host
                        Write-Host "Invalid service name - service does not exist"
                    }
                }

                elseif ($local_remote -eq 2) { # if running remotely

                    # basically same thing as local except running commands remotely
                    Write-Host
                    Invoke-Command -Session $session -ScriptBlock { $servicename = Read-Host "Enter a service name" }
                    $servicename = Invoke-Command -Session $session -ScriptBlock { $servicename }

                    if ($servicename.Length -eq 0) {
                        Write-Host
                        Write-Host "Invalid service name - service name cannot be empty"
                    }

                    elseif (Invoke-Command -Session $session -ScriptBlock { Get-Service $servicename -ErrorAction SilentlyContinue }) {
                        $valid_servicename = $true

                        if (Invoke-Command -Session $session -ScriptBlock { (Get-Service $servicename).Status -eq "Running" }) {
                            Write-Host
                            Write-Host "Stopping service" $servicename
                            Invoke-Command -Session $session -ScriptBlock { Stop-Service $servicename }
                        }

                        else {
                            Write-Host
                            Write-Host "Starting service" $servicename
                            Invoke-Command -Session $session -ScriptBlock { Start-Service $servicename }
                        }
                    }

                    else {
                        Write-Host
                        Write-Host "Invalid service name - service does not exist"
                    }
                }

                else {
                    Write-Host "Something went wrong"
                }
                
            } until ($valid_servicename)
        }
        7 { <# 
              - set the IP address (local only)
              - IP and subnet mask - current IP is removed and replaced by user input, subnet mask assigned automatically based on IP class
              - default gateway option - current gateway is removed and replaced by user input
              - DNS address option - current address is replaced by user input
            #>
            Write-Host
            $validip = $false

            do {
                Write-Host
                $new_ip = Read-Host "Enter the new IP Address (eg. 192.168.202.123)"
                # ***Bonus - validating IP octets
                $split_ip = $new_ip.Split(".")

                foreach ($octet in $split_ip){ # for each octec in entered IP

                    # regex found at https://stackoverflow.com/a/51172049
                    if ($octet -match "^\d+$") { # if octec contains only digits

                        if ($octet -gt 0 -and $octet -lt 255) { # if octet is in correct range
                            $validip = $true # ip is accepted
                        }
                    }
                }

                if (-not $validip) {
                    Write-Host
                    Write-Host "Invalid IP"
                }

            } until ($validip)

            # Class A subnet mask
            if ($split_ip[0] -lt 128) {
                $subnetmask = 8
            }
            # Class B subnet mask
            elseif ($split_ip[0] -lt 192) {
                $subnetmask = 16
            }
            # Class C subnet mask
            else {
                $subnetmask = 24
            }

            # https://devblogs.microsoft.com/scripting/using-powershell-to-find-connected-network-adapters/
            # isolate correct interface by looking at "connected" interfaces (assuming there is only one on VMs, that was the case with my test machines)
            $interface = Get-WmiObject win32_networkadapter -filter "netconnectionstatus = 2" 
            $interfaceindex = $interface.InterfaceIndex

            $valid_gchoice = $false
            do {
                Write-Host
                $gatewaychoice = Read-Host "Change default gateway? 1 for yes, 2 for no" # option to change default gateway

                if ($gatewaychoice -eq "1" -or $gatewaychoice -eq "2") {
                    $valid_gchoice = $true

                    if ($gatewaychoice -eq 1) { # if user wants to change gateway
                        Write-Host
                        # no error checking for default gateway
                        $new_gateway = Read-Host "Enter new default gateway"
                    }
                }

                else {
                    Write-Host
                    Write-Host "Invalid choice"
                }

            } until ($valid_gchoice)

            Remove-NetIPAddress -InterfaceIndex $interfaceindex # remove current IP address on interface

            if ($gatewaychoice -eq 1) { # if new gateway
                # https://etechgoodness.wordpress.com/2013/01/18/removing-an-adapter-gateway-using-powershell/
                Remove-NetRoute -InterfaceIndex $interfaceindex -DestinationPrefix 0.0.0.0/0 # remove current gateway
                # set new IP address and gateway
                New-NetIPAddress -InterfaceIndex $interfaceindex -IPAddress $new_ip -PrefixLength $subnetmask -DefaultGateway $new_gateway > $null
                Write-Host "IP Address set to" $new_ip
                Write-Host "Default gateway set to" $new_gateway
            }
            else {
                # set new IP address
                New-NetIPAddress -InterfaceIndex $interfaceindex -IPAddress $new_ip -PrefixLength $subnetmask > $null
                Write-Host
                Write-Host "IP Address set to" $new_ip
            }

            $valid_dchoice = $false

            do {
                $dnschoice = Read-Host "Change DNS server address? 1 for yes, 2 for no" # option to change DNS address

                if ($dnschoice -eq "1" -or $dnschoice -eq "2") {
                    $valid_dchoice = $true

                    if ($dnschoice -eq 1) { # if user wants to change DNS address
                        # no error checking for dns address
                        Write-Host
                        $new_dns = Read-Host "Enter new dns address"
                        # https://docs.microsoft.com/en-us/powershell/module/dnsclient/set-dnsclientserveraddress?view=windowsserver2019-ps
                        # current DNS address on interface replaced by user input
                        Set-DnsClientServerAddress -InterfaceIndex $interfaceindex -ServerAddresses ($new_dns)
                        Write-Host
                        Write-Host "DNS address set to" $new_dns
                    }
                }

                else {
                    Write-Host
                    Write-Host "Invalid choice"
                }

            } until ($valid_dchoice)
            
        }
        8 { # test connectivity to a machine return True (active) or False (no response)
            $validitem = $false

            do {
                Write-Host
                $item_to_ping = Read-Host "Enter item to ping (IP address or name)"

                if ($item_to_ping.Length -eq 0) {
                    Write-Host
                    Write-Host "Invalid item - must not be blank"
                }

                else {
                    $validitem = $true
                }

            } until ($validitem)

            # https://docs.microsoft.com/en-us/powershell/module/microsoft.powershell.management/test-connection?view=powershell-5.1
            # ping specified machine/address
            $ping_result = Test-Connection -ComputerName $item_to_ping -ErrorAction SilentlyContinue
            Write-Host

            if ($ping_result -eq $null) { # if no ping response
                Write-Host "FALSE" 
            }

            else { # successful ping
                Write-Host "TRUE"
            }
        }

        Default {$running = $false} # 9 = exit
    }
}

if ($local_remote -eq 2) { # if running remotely
    $session | Remove-PSSession
}
Write-Host
Write-Host "Press any key to exit."
[void][System.Console]::ReadKey($true)