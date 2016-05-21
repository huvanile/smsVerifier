Public Class Form1
    Dim LookupPage As String = "http://www.receive-sms-online.info/read-sms.php?phone="
    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        ListView1.Columns.Add("From", 100, HorizontalAlignment.Center) 'Column 1
        ListView1.Columns.Add("Body", 100, HorizontalAlignment.Center) 'Column 2
        ListView1.Columns.Add("Date/Time", 100, HorizontalAlignment.Center) 'Column 3

        Dim WC As New System.Net.WebClient
        Dim Result As String = WC.DownloadString("http://www.receive-sms-online.info/")

        Dim YourPage As String = ""
        Dim X() As String = Split(Result, "read-sms.php?phone=")
        Dim firstpass As Boolean = True
        For Each y In X
            If firstpass = True Then firstpass = False : Continue For
            Dim XY() As String = Split(y, """")
            XY = XY
            ' Console.Title = "Your Phone # " & XY(0)
            ComboBox1.Items.Add(XY(0))
        Next
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        ListView1.Items.Clear()
        Dim WC As New System.Net.WebClient
        Dim result As String = WC.DownloadString(LookupPage & ComboBox1.Text)
        Dim X() As String = Split(result, "<tr>")
        For i = 2 To X.Length - 1
            Dim XY() As String = Split(X(i), "</td>")
            If XY.Length = 1 Then Continue For
            Dim From As String = Replace(XY(0), "<td>", "")
            Dim Message As String = Replace(XY(1), "<td>", "")
            Dim Whenz As String = Trim(Replace(XY(2), "<td>", ""))

            Dim str(2) As String
            Dim itm As ListViewItem
            str(0) = From
            str(1) = Message
            str(2) = Whenz


            itm = New ListViewItem(str)
            ListView1.Items.Add(itm)
            Application.DoEvents()
        Next


    End Sub
End Class
