Imports Microsoft.Win32

Module Module1
    Sub Main()
        Console.WriteLine("This program will disable 'IPChecksumOffloadIPv4' in Registry. Make sure run this program as Administrator" & vbCrLf & vbCrLf & "Enter Y to proceed / Enter N to exit")
        Dim info = Console.ReadLine()

        If info.ToUpper = "Y" Then
            Dim inputRegistry As RegistryKey

            'local PC
            inputRegistry = Registry.LocalMachine.OpenSubKey("SYSTEM\CurrentControlSet\Control\Class\{4d36e972-e325-11ce-bfc1-08002be10318}\0001", True)

            'Below 2 for remote pc. 'Remote Registry' in Services.msc has to be enabled.
            'inputRegistry = RegistryKey.OpenRemoteBaseKey(RegistryHive.LocalMachine, "AMMVWCZD81T3-L")
            'inputRegistry = inputRegistry.OpenSubKey("SYSTEM\CurrentControlSet\Control\Class\{4d36e972-e325-11ce-bfc1-08002be10318}\0001", True)
            inputRegistry.SetValue("*IPChecksumOffloadIPv4", "0")
            Console.WriteLine("IPChecksumOffloadIPv4 is disabled. Press any key to exit")
            Console.ReadKey(True)
        ElseIf info.ToUpper = "N" Then
            Exit Sub
        Else
            Console.WriteLine("Invalid Entry. Press any key to exit")
            Console.ReadKey(True)
        End If
    End Sub
End Module
