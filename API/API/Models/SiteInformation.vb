Imports System
Imports System.Collections.Generic
Imports System.ComponentModel.DataAnnotations
Imports System.ComponentModel.DataAnnotations.Schema
Imports System.Data.Entity.Spatial

<Table("SiteInformation")>
Partial Public Class SiteInformation
    <Key>
    Public Property SiteId As Integer

    <Required>
    Public Property SiteName As String

    Public Property SiteDetail As String

    Public Property Address As String

    Public Property SiteArea As Integer

    Public Property SiteEstimation As Integer

    <Required>
    Public Property SiteImage As String
End Class
