Imports MineGenerator.Models
Imports MineGenerator.Views

Namespace ViewModels

    Public Class LeftBarViewModel
        Inherits ViewModelBase(Of LeftBarViewModel)

        Public ReadOnly Property Data As New List(Of LeftBarModel) From {
            New LeftBarModel(ChrW(&HE10F), New MainPage),
            New LeftBarModel(ChrW(&HE11B), New AboutPage)
        }
    End Class
End Namespace