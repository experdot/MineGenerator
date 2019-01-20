Namespace Models
    ''' <summary>
    ''' 页面的入口和介绍
    ''' </summary>
    Public Class PageEntry
        ''' <summary>
        ''' 初始化页面的入口和介绍
        ''' </summary>
        ''' <param name="title">页面标题</param>
        ''' <param name="description">页面描述</param>
        ''' <param name="page">导航到的页面</param>
        Sub New(title As String, description As String, page As Page)
            Me.Title = title
            Me.Description = description
            Me.Page = page
        End Sub
        ''' <summary>
        ''' 页面标题
        ''' </summary>
        Public ReadOnly Property Title As String
        ''' <summary>
        ''' 页面描述
        ''' </summary>
        Public ReadOnly Property Description As String
        ''' <summary>
        ''' 导航到的页面
        ''' </summary>
        Public ReadOnly Property Page As Page

        Shared _navigateCommand As New Commands.NavigateToPageCommand
        ''' <summary>
        ''' 导航命令
        ''' </summary>
        Public ReadOnly Property Navigate As ICommand
            Get
                Return _navigateCommand
            End Get
        End Property
    End Class

End Namespace