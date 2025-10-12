Public Class LoginAnimationService
    Private  Const START_Y As Integer = 20  ' Y position of the label when inside the textbox
    Private Const END_Y As Integer = 2    ' Y position of the label when floating above
    Private Const ANIMATION_STEP As Integer = 3 ' How many pixels to move per timer tick

    Private Shared IsAnimatingUp As Boolean = False
    Private Shared IsAnimatingDown As Boolean = False

    Public Shared Function TimerAnimation(labelHolder As Label)
        If IsAnimatingUp Then
            ' Move the label up
            labelHolder.Top -= ANIMATION_STEP

            If labelHolder.Top <= END_Y Then
                ' Animation finished moving up
                labelHolder.Top = END_Y
                Login.TimerAnimator.Stop()
                IsAnimatingUp = False
            End If

        ElseIf IsAnimatingDown Then
            ' Move the label down
            labelHolder.Top += ANIMATION_STEP

            If labelHolder.Top >= START_Y Then
                ' Animation finished moving down
                labelHolder.Top = START_Y
                Login.TimerAnimator.Stop()
                IsAnimatingDown = False
            End If
        End If
        Return labelHolder
    End Function
    Public Shared Function TextBoxChanged(textBox As TextBox, labelHolder As Label)
        If Not String.IsNullOrEmpty(textBox.Text) Then
            labelHolder.Visible = False
        Else
            labelHolder.Visible = True
        End If
        Return textBox
    End Function
    Public Shared Function TextBoxEnter(textBox As TextBox, labelHolder As Label)
        If String.IsNullOrEmpty(textBox.Text) Then
            If labelHolder.Top > END_Y Then
                IsAnimatingUp = True
                IsAnimatingDown = False
                Login.TimerAnimator.Start()
            End If
        End If
        Return textBox
    End Function
    Public Shared Function TextBoxLeave(textBox As TextBox, labelHolder As Label)
        If String.IsNullOrEmpty(textBox.Text) Then
            If labelHolder.Top < START_Y Then
                IsAnimatingUp = False
                IsAnimatingDown = True
                Login.TimerAnimator.Start()
            End If
        End If
        Return textBox
    End Function
End Class
Public Class LoginAnimationServiceForPassword
    Private Const START_Y As Integer = 20  ' Y position of the label when inside the textbox
    Private Const END_Y As Integer = 2    ' Y position of the label when floating above
    Private Const ANIMATION_STEP As Integer = 3 ' How many pixels to move per timer tick

    Private Shared IsAnimatingUp As Boolean = False
    Private Shared IsAnimatingDown As Boolean = False

    Public Shared Function TimerAnimation(labelHolder As Label)
        If IsAnimatingUp Then
            ' Move the label up
            labelHolder.Top -= ANIMATION_STEP

            If labelHolder.Top <= END_Y Then
                ' Animation finished moving up
                labelHolder.Top = END_Y
                Login.TimerAnimator1.Stop()
                IsAnimatingUp = False
            End If

        ElseIf IsAnimatingDown Then
            ' Move the label down
            labelHolder.Top += ANIMATION_STEP

            If labelHolder.Top >= START_Y Then
                ' Animation finished moving down
                labelHolder.Top = START_Y
                Login.TimerAnimator1.Stop()
                IsAnimatingDown = False
            End If
        End If
        Return labelHolder
    End Function
    Public Shared Function TextBoxChanged(textBox As TextBox, labelHolder As Label)
        If Not String.IsNullOrEmpty(textBox.Text) Then
            labelHolder.Visible = False
        Else
            labelHolder.Visible = True
        End If
        Return textBox
    End Function
    Public Shared Function TextBoxEnter(textBox As TextBox, labelHolder As Label)
        If String.IsNullOrEmpty(textBox.Text) Then
            If labelHolder.Top > END_Y Then
                IsAnimatingUp = True
                IsAnimatingDown = False
                Login.TimerAnimator1.Start()
            End If
        End If
        Return textBox
    End Function
    Public Shared Function TextBoxLeave(textBox As TextBox, labelHolder As Label)
        If String.IsNullOrEmpty(textBox.Text) Then
            If labelHolder.Top < START_Y Then
                IsAnimatingUp = False
                IsAnimatingDown = True
                Login.TimerAnimator1.Start()
            End If
        End If
        Return textBox
    End Function
End Class
