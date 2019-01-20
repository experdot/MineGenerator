Namespace Models

    Public Structure VirginiaContentChar
        Dim Value As Char

        Const LowerA = AscW("a"c)
        Const UpperA = AscW("A"c)

        Sub New(value As Char)
            If Char.IsUpper(value) OrElse Char.IsLower(value) Then
                Me.Value = value
            Else
                Throw New ArgumentOutOfRangeException(NameOf(value), "文本必须是字母")
            End If
        End Sub

        Sub New(charCode As Integer)
            MyClass.New(ChrW(charCode))
        End Sub

        Public Shared Operator +(chr As VirginiaContentChar, key As Char) As VirginiaContentChar
            AssertIsLower(key)
            Return New VirginiaContentChar(((AscW(chr.Value) - LowerA + AscW(key) - LowerA) Mod 26) + UpperA)
        End Operator

        Private Shared Sub AssertIsLower(key As Char)
            If Not (Char.IsLower(key)) Then
                Throw New ArgumentOutOfRangeException(NameOf(key))
            End If
        End Sub

        Public Shared Operator -(chr As VirginiaContentChar, key As Char) As VirginiaContentChar
            AssertIsLower(key)
            Return New VirginiaContentChar(((AscW(chr.Value) - UpperA - (AscW(key) - LowerA) + 26) Mod 26) + LowerA)
        End Operator
    End Structure

End Namespace