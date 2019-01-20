Namespace Models
    ''' <summary>
    ''' 汉堡菜单的内容
    ''' </summary>
    Public Class LeftBarModel
        ''' <summary>
        ''' Segoe Assets MDL2 的字体图标
        ''' </summary>
        Public ReadOnly Property Symbol$
        ''' <summary>
        ''' 导航到的页面
        ''' </summary>
        Public ReadOnly Property AssocPage As Page

        ''' <summary>
        ''' 初始化一条汉堡菜单的内容
        ''' </summary>
        ''' <param name="Symbol">Segoe Assets MDL2 的字体图标</param>
        ''' <param name="AssocPage">导航到的页面</param>
        Sub New(Symbol$, AssocPage As Page)
            Me.Symbol = Symbol
            Me.AssocPage = AssocPage
        End Sub
    End Class

End Namespace