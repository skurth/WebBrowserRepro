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
  End Sub

End Class
