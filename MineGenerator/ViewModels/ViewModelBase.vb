Imports MineGenerator.Helpers

Namespace ViewModels

    Public Class ViewModelBase(Of T As {New, ViewModelBase(Of T)})
        Inherits Singleton(Of T)
    End Class

End Namespace