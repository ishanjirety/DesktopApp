Imports System.Data.OleDb
Module Module1
    Public con As New OleDbConnection("Provider=Microsoft.ACE.OLEDB.12.0;" + "Data Source=D:\Billing.accdb")
    'Provider=Microsoft.ACE.OLEDB.12.0;Data Source=I:\Billing.accdb
    Public cmd As New OleDbCommand
    Public da As New OleDbDataAdapter
    Public ds As New DataSet
    Public str As String
    Public tempo As Integer
End Module
Module Module2
    Public gstnew As Integer
    Public dt As String
    Public pdt As String
    Public pcs As Integer
    Public dis As Integer
    Public amt As Integer
    Public a As Integer
    Public d As Integer
    Public d1 As String
    Public d2 As String
    Public new1 As Integer
    Public count As Integer = 0
    Public count1 As Integer = 0
    Public dash As Integer = 0
    Public e1 As Integer
    Public f1 As Integer
    Public cpy As Integer
    Public cpy1 As Integer
    Public cpy2 As String
    Public c As String
    Public textcpy As String
End Module
Module module3
    Public namecpy As String
    Public numcpy As String
    Public addcpy As String
    Public dtecpy As String
    Public remarkcpy As String
    Public invcpy As Integer
    Public dis1 As String
    Public emp As Integer
End Module
Module RefundMod
    Public rname As String
    Public rmob As String
    Public raddr As String
    Public rdt As String
    Public rinv As Integer
    Public rpn As String
    Public rpt As String
    Public rsno As String
    Public rrte As Integer
    Public rcpy As String
    Public rstk As String
    Public rnamecpy As String
    Public sum1 As Integer

End Module
Module invoice
    Public list2pdt As String
    Public list3amt As String
    Public list4batch As String
    Public list5pcs As String
    Public list6dis As String
    Public list78sum1 As String
    Public newadder As Integer = 0
    Public list2pdtcpy As String
    Public list3amtcpy As String
    Public list4batchcpy As String
    Public list5pcscpy As String
    Public list6discpy As String
    Public list78sum1cpy As String
    Public login As String
End Module
Module Billcopy
    Public NameB As String
    Public addB As String
    Public mobB As String
    Public tItemB As String
    Public VOGB As String
    Public AdisB As String
    Public MdeB As String
    Public Ysave As String
    Public invB As String
    Public dateB As String
End Module
