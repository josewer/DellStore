﻿#ExternalChecksum("..\..\Productos.xaml","{406ea660-64cf-4c82-b6f0-42d48172a799}","60E924155380419DA2B808DFD88339AE")
'------------------------------------------------------------------------------
' <auto-generated>
'     Este código fue generado por una herramienta.
'     Versión de runtime:4.0.30319.42000
'
'     Los cambios en este archivo podrían causar un comportamiento incorrecto y se perderán si
'     se vuelve a generar el código.
' </auto-generated>
'------------------------------------------------------------------------------

Option Strict Off
Option Explicit On

Imports CapaPresentacion
Imports System
Imports System.Diagnostics
Imports System.Windows
Imports System.Windows.Automation
Imports System.Windows.Controls
Imports System.Windows.Controls.Primitives
Imports System.Windows.Data
Imports System.Windows.Documents
Imports System.Windows.Ink
Imports System.Windows.Input
Imports System.Windows.Markup
Imports System.Windows.Media
Imports System.Windows.Media.Animation
Imports System.Windows.Media.Effects
Imports System.Windows.Media.Imaging
Imports System.Windows.Media.Media3D
Imports System.Windows.Media.TextFormatting
Imports System.Windows.Navigation
Imports System.Windows.Shapes
Imports System.Windows.Shell


'''<summary>
'''Productos
'''</summary>
<Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>  _
Partial Public Class Productos
    Inherits System.Windows.Window
    Implements System.Windows.Markup.IComponentConnector
    
    
    #ExternalSource("..\..\Productos.xaml",12)
    <System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")>  _
    Friend WithEvents lvProductos As System.Windows.Controls.ListView
    
    #End ExternalSource
    
    
    #ExternalSource("..\..\Productos.xaml",40)
    <System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")>  _
    Friend WithEvents cbCategorias As System.Windows.Controls.ComboBox
    
    #End ExternalSource
    
    
    #ExternalSource("..\..\Productos.xaml",41)
    <System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")>  _
    Friend WithEvents btCerrar As System.Windows.Controls.Button
    
    #End ExternalSource
    
    
    #ExternalSource("..\..\Productos.xaml",42)
    <System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")>  _
    Friend WithEvents btAdd As System.Windows.Controls.Button
    
    #End ExternalSource
    
    
    #ExternalSource("..\..\Productos.xaml",43)
    <System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")>  _
    Friend WithEvents lbTitle As System.Windows.Controls.Label
    
    #End ExternalSource
    
    
    #ExternalSource("..\..\Productos.xaml",44)
    <System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")>  _
    Friend WithEvents tbCantidad As System.Windows.Controls.TextBox
    
    #End ExternalSource
    
    
    #ExternalSource("..\..\Productos.xaml",45)
    <System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")>  _
    Friend WithEvents label As System.Windows.Controls.Label
    
    #End ExternalSource
    
    
    #ExternalSource("..\..\Productos.xaml",46)
    <System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")>  _
    Friend WithEvents label1 As System.Windows.Controls.Label
    
    #End ExternalSource
    
    
    #ExternalSource("..\..\Productos.xaml",47)
    <System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")>  _
    Friend WithEvents label2 As System.Windows.Controls.Label
    
    #End ExternalSource
    
    
    #ExternalSource("..\..\Productos.xaml",48)
    <System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")>  _
    Friend WithEvents tbTitulo As System.Windows.Controls.TextBox
    
    #End ExternalSource
    
    
    #ExternalSource("..\..\Productos.xaml",49)
    <System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")>  _
    Friend WithEvents image As System.Windows.Controls.Image
    
    #End ExternalSource
    
    Private _contentLoaded As Boolean
    
    '''<summary>
    '''InitializeComponent
    '''</summary>
    <System.Diagnostics.DebuggerNonUserCodeAttribute(),  _
     System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "4.0.0.0")>  _
    Public Sub InitializeComponent() Implements System.Windows.Markup.IComponentConnector.InitializeComponent
        If _contentLoaded Then
            Return
        End If
        _contentLoaded = true
        Dim resourceLocater As System.Uri = New System.Uri("/CapaPresentacion;component/productos.xaml", System.UriKind.Relative)
        
        #ExternalSource("..\..\Productos.xaml",1)
        System.Windows.Application.LoadComponent(Me, resourceLocater)
        
        #End ExternalSource
    End Sub
    
    <System.Diagnostics.DebuggerNonUserCodeAttribute(),  _
     System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "4.0.0.0"),  _
     System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never),  _
     System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Design", "CA1033:InterfaceMethodsShouldBeCallableByChildTypes"),  _
     System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Maintainability", "CA1502:AvoidExcessiveComplexity"),  _
     System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1800:DoNotCastUnnecessarily")>  _
    Sub System_Windows_Markup_IComponentConnector_Connect(ByVal connectionId As Integer, ByVal target As Object) Implements System.Windows.Markup.IComponentConnector.Connect
        If (connectionId = 1) Then
            
            #ExternalSource("..\..\Productos.xaml",7)
            AddHandler CType(target,Productos).Closing, New System.ComponentModel.CancelEventHandler(AddressOf Me.Window_Closing)
            
            #End ExternalSource
            Return
        End If
        If (connectionId = 2) Then
            Me.lvProductos = CType(target,System.Windows.Controls.ListView)
            
            #ExternalSource("..\..\Productos.xaml",11)
            AddHandler Me.lvProductos.SelectionChanged, New System.Windows.Controls.SelectionChangedEventHandler(AddressOf Me.lvProductos_SelectionChanged)
            
            #End ExternalSource
            Return
        End If
        If (connectionId = 3) Then
            Me.cbCategorias = CType(target,System.Windows.Controls.ComboBox)
            
            #ExternalSource("..\..\Productos.xaml",40)
            AddHandler Me.cbCategorias.SelectionChanged, New System.Windows.Controls.SelectionChangedEventHandler(AddressOf Me.cbCategorias_SelectionChanged)
            
            #End ExternalSource
            Return
        End If
        If (connectionId = 4) Then
            Me.btCerrar = CType(target,System.Windows.Controls.Button)
            
            #ExternalSource("..\..\Productos.xaml",41)
            AddHandler Me.btCerrar.Click, New System.Windows.RoutedEventHandler(AddressOf Me.btCerrar_Click)
            
            #End ExternalSource
            Return
        End If
        If (connectionId = 5) Then
            Me.btAdd = CType(target,System.Windows.Controls.Button)
            
            #ExternalSource("..\..\Productos.xaml",42)
            AddHandler Me.btAdd.Click, New System.Windows.RoutedEventHandler(AddressOf Me.btAdd_Click)
            
            #End ExternalSource
            Return
        End If
        If (connectionId = 6) Then
            Me.lbTitle = CType(target,System.Windows.Controls.Label)
            Return
        End If
        If (connectionId = 7) Then
            Me.tbCantidad = CType(target,System.Windows.Controls.TextBox)
            
            #ExternalSource("..\..\Productos.xaml",44)
            AddHandler Me.tbCantidad.TextChanged, New System.Windows.Controls.TextChangedEventHandler(AddressOf Me.tbCantidad_TextChanged)
            
            #End ExternalSource
            Return
        End If
        If (connectionId = 8) Then
            Me.label = CType(target,System.Windows.Controls.Label)
            Return
        End If
        If (connectionId = 9) Then
            Me.label1 = CType(target,System.Windows.Controls.Label)
            Return
        End If
        If (connectionId = 10) Then
            Me.label2 = CType(target,System.Windows.Controls.Label)
            Return
        End If
        If (connectionId = 11) Then
            Me.tbTitulo = CType(target,System.Windows.Controls.TextBox)
            
            #ExternalSource("..\..\Productos.xaml",48)
            AddHandler Me.tbTitulo.TextChanged, New System.Windows.Controls.TextChangedEventHandler(AddressOf Me.tbTitulo_TextChanged)
            
            #End ExternalSource
            Return
        End If
        If (connectionId = 12) Then
            Me.image = CType(target,System.Windows.Controls.Image)
            Return
        End If
        Me._contentLoaded = true
    End Sub
End Class

