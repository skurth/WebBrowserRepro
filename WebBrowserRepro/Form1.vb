Imports System.IO

Public Class Form1

  Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
    'WebControlManager.IEbrowserFix() 'If you uncomment this line, FEATURE_BROWSER_EMULATION is set in registry and it works again. But this is NO solution for us!

    WebBrowser1.ScriptErrorsSuppressed = False
    Dim sHtml As String = My.Resources.test
    'File.WriteAllText("C:\Temp\test.html", sHtml)
    'WebBrowser1.Url = New Uri("C:\Temp\test.html")
    'WebBrowser1.Url = New Uri("File:///C:\Temp\test.html")
    WebBrowser1.DocumentText = sHtml


    'Test Commit in Branch 1
    'Noch ein Commit in Branch 1
    'Noch ein Commit in Branch 1 dfsdsf
    'Noch ein Commit in Branch 1 4
    
    'Commit in Branch-2

    'Commit in master

    'Commit in Branch 3 again
  End Sub

End Class
