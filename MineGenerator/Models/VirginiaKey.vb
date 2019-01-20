Namespace Models

    Public Class VirginiaKey
        Sub New(value As String)
            If String.IsNullOrEmpty(value) Then
                Throw New ArgumentException("密钥不得为空")
            End If
            If (Aggregate c In value Where Char.IsLower(c) Into Count) <> value.Length Then
                Throw New ArgumentException("密钥必须是小写的英文字母")
            End If
            _Value = value
        End Sub

        ReadOnly _Value As String

        Default Public ReadOnly Property Item(index As Integer) As Char
            Get
                Return _Value(index Mod _Value.Length)
            End Get
        End Property

        Public Overrides Function ToString() As String
            Return _Value
        End Function
    End Class

End Namespace