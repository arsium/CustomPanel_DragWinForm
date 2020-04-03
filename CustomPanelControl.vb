Imports System.Runtime.InteropServices

Public Class CustomPanelControl
    Inherits Panel

    Sub New()
        SetStyle(ControlStyles.AllPaintingInWmPaint Or ControlStyles.OptimizedDoubleBuffer Or ControlStyles.ResizeRedraw Or ControlStyles.UserPaint, True)
        DoubleBuffered = True
    End Sub
    Protected Overrides Sub CreateHandle()
        MyBase.CreateHandle()


    End Sub

    Protected Overrides Sub OnPaint(e As PaintEventArgs)
        Dim B As New Bitmap(Width, Height)
        Dim g As Graphics = Graphics.FromImage(B)


        '    g.Clear(Color.FromArgb(100, 100, 100))


        ' Dim o As Brushes = Color.FromArgb(37, 37, 37)

        '    Dim l = New SolidBrush(Color.FromArgb(100, 100, 100))

        e.Graphics.DrawImage(B.Clone, 0, 0)
        e.Graphics.SmoothingMode = Drawing2D.SmoothingMode.HighQuality


        g.Dispose() : B.Dispose()

        MyBase.OnPaint(e)
    End Sub
    <DllImport("user32.dll")>
    Public Shared Function SendMessage(ByVal a As IntPtr, ByVal msg As Integer, ByVal wParam As Integer, ByVal lParam As Integer) As Integer
    End Function
    <DllImport("user32.dll")>
    Public Shared Function ReleaseCapture() As Boolean
    End Function
    Protected Overrides Sub OnMouseDown(e As MouseEventArgs)
        Dim flag As Boolean = e.Button = MouseButtons.Left
        If flag Then
            CustomPanelControl.ReleaseCapture()
            CustomPanelControl.SendMessage(Me.FindForm().Handle, 161, 2, 0)
        End If
        MyBase.OnMouseDown(e)
    End Sub
End Class
