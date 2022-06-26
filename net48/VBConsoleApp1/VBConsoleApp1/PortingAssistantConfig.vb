Public Class PortingAssistantAppConfiguration
    Public Property PortingAssistantConfiguration As PortingAssistantConfiguration
    Public Property DataStoreSettings As DataStoreSettings
    Public Property PortingAssistantMetrics As PortingAssistantMetrics
End Class

Public Class PortingAssistantConfiguration
    Public Property DataStoreSettings As DataStoreSettings

End Class

Public Class DataStoreSettings
    Public Property HttpsEndpoint As String
    Public Property S3Endpoint As String
    Public Property GitHubEndpoint As String
End Class
Public Class PortingAssistantMetrics
    Public Property InvokeUrl As String
    Public Property Region As String
    Public Property ServiceName As String
    Public Property MaxBufferCapacity As Integer
    Public Property MaxBufferCache As Integer
    Public Property FlushInterval As Integer
    Public Property LogTimerInterval As Integer
    Public Property Prefix As String
    Public Property Description As String
End Class

Public Class CustomerContributionConfiguration
    Public Property CustomerFeedbackEndpoint As String
    Public Property RuleContributionEndpoint As String
End Class