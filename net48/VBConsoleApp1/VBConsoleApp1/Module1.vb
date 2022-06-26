
Imports System.Reflection
Imports System
Imports System.IO, System.Collections
Imports Newtonsoft.Json
Imports System.Web
Imports Microsoft.Owin.Security
Imports Microsoft.Owin.Security.Infrastructure
Imports Org.BouncyCastle.Security
Imports VBConsoleApp1.VbConsoleApp1

Module Module1

    Sub Main()
        Console.WriteLine("Hello World")

        'this is a comment
        Dim num = Math.Abs(-1).ToString()

        Dim person As New Person("Reading")
        person.SetName("Chris")
        Console.WriteLine(person.Name)
        Console.WriteLine(person.GetName())

        Dim fileInput = Console.ReadLine()
        Dim jsonFile
        If fileInput IsNot "" Then
            jsonFile = fileInput
        Else
            jsonFile = "D:\\Users\\longachr\\Desktop\\porting-assistant-config.json"
        End If

        Dim lst As List(Of Integer) = New List(Of Integer)() From {1, 8, 45, 70}
        Dim i = lst(0)
        Console.WriteLine(i)

        Dim request As New HttpRequest("", "http://localhost", "")

        Dim fileReader As New StreamReader(CStr(jsonFile))
        Dim fileText As String = fileReader.ReadToEnd()
        Dim portingAssistantConfig As PortingAssistantAppConfiguration = JsonConvert.DeserializeObject(Of PortingAssistantAppConfiguration)(fileText)
        Console.WriteLine(portingAssistantConfig.PortingAssistantMetrics.Region)

        Dim dictionary = New Dictionary(Of Integer, Integer)()
        ' Add data by assigning to a key.
        dictionary(10) = 20
        ' Look up value.
        Console.WriteLine(dictionary(10))
        Console.WriteLine(dictionary.Item(10))

        Dim person2 As Person = New Person("games") With {.Name= "Terry", .Age = 21}

        Dim increment1 = Function(x) x + 1 : Dim increment2 = Function(x) x +2
        Dim random = New SecureRandom()
        Console.WriteLine(random.Next())
        Console.ReadKey()
    End Sub

    Function OwinSecurityInfrastructure(create As AuthenticationTokenCreateContext, receive As AuthenticationTokenReceiveContext) As String
        Dim serializedTicket As String = create.SerializeTicket()
        create.SetToken("")
        receive.DeserializeTicket(serializedTicket)

        Dim helper As SecurityHelper = New SecurityHelper()
        helper.LookupChallenge("Authentication_Type", AuthenticationMode.Active)
        Return ""
    End Function

    Function TestFunction()
        'Console.WriteLine("This is a function with no return")
    End Function
    
    'Sub TestSub
        ' Comment
        ' Comment2
    'End Sub

End Module
