Option Explicit On
Option Strict On

Public Class Customers

    Private _CustomerId As Integer ' not null
    Public Property CustomerId() As Integer
        Get
            Return _CustomerId
        End Get
        Set(ByVal value As Integer)
            If value = Nothing Then
                Throw New Exception("CustomerId no puede ser nulo")
            Else
                _CustomerId = value
            End If
        End Set
    End Property


    Private _FirstName As String ' varying(50) Not NULL,
    Public Property FirstName() As String
        Get
            Return _FirstName
        End Get
        Set(ByVal value As String)
            If value Is Nothing Then
                Throw New Exception("FirstName no puede ser nulo.")
            ElseIf value.Length > 50 Then
                Throw New Exception("FirstName no puede tener más de 50 cáracteres.")
            Else
                _FirstName = value
            End If
        End Set
    End Property


    Private _LastName As String ' varying(50) Not NULL,
    Public Property LastName() As String
        Get
            Return _LastName
        End Get
        Set(ByVal value As String)
            If value Is Nothing Then
                Throw New Exception("LastName no puede ser nulo.")
            ElseIf value.Length > 50 Then
                Throw New Exception("LastName no puede tener más de 50 cáracteres.")
            Else
                _LastName = value
            End If
        End Set
    End Property


    Private _Address1 As String ' varying(50) Not NULL,
    Public Property Address1() As String
        Get
            Return _Address1
        End Get
        Set(ByVal value As String)
            If value Is Nothing Then
                Throw New Exception("Address1 no puede ser nulo.")
            ElseIf value.Length > 50 Then
                Throw New Exception("Address1 no puede tener más de 50 cáracteres.")
            Else
                _Address1 = value
            End If
        End Set
    End Property


    Private _Address2 As String ' varying(50),
    Public Property Address2() As String
        Get
            Return _Address2
        End Get
        Set(ByVal value As String)
            If value.Length > 50 Then
                Throw New Exception("Address2 no puede tener más de 50 cáracteres.")
            Else
                _Address2 = value
            End If
        End Set
    End Property


    Private _City As String ' varying(50) Not NULL,
    Public Property City() As String
        Get
            Return _City
        End Get
        Set(ByVal value As String)
            If value Is Nothing Then
                Throw New Exception("City no puede ser nulo.")
            ElseIf value.Length > 50 Then
                Throw New Exception("City no puede tener más de 50 cáracteres.")
            Else
                _City = value
            End If
        End Set
    End Property


    Private _State As String ' varying(50),
    Public Property State() As String
        Get
            Return _State
        End Get
        Set(ByVal value As String)
            If value.Length > 50 Then
                Throw New Exception("State no puede tener más de 50 cáracteres.")
            Else
                _State = value
            End If
        End Set
    End Property


    Private _Zip As Integer
    Public Property Zip() As Integer
        Get
            Return _Zip
        End Get
        Set(ByVal value As Integer)
            If IsNumeric(value) Then
                _Zip = value
            Else
                Throw New Exception("Zip tiene que ser númerico.")
            End If
        End Set
    End Property


    Private _Country As String ' varying(50) Not NULL,
    Public Property Country() As String
        Get
            Return _Country
        End Get
        Set(ByVal value As String)
            If value Is Nothing Then
                Throw New Exception("Country no puede ser nulo.")
            ElseIf value.Length > 50 Then
                Throw New Exception("Country no puede tener más de 50 cáracteres.")
            Else
                _Country = value
            End If
        End Set
    End Property


    Private _Region As Short ' not null
    Public Property Region() As Short

        Get
            Return _Region
        End Get
        Set(ByVal value As Short)
            If value = Nothing And value <> 0 Then
                Throw New Exception("Region no puede ser nulo")
            ElseIf IsNumeric(value) <> True Then
                Throw New Exception("Region tiene que ser númerico.")
            Else
                _Region = value
            End If
        End Set
    End Property


    Private _Email As String ' varying(50),
    Public Property Email() As String
        Get
            Return _Email
        End Get
        Set(ByVal value As String)
            If value.Length > 50 Then
                Throw New Exception("Email no puede tener más de 50 cáracteres.")
            Else
                _Email = value
            End If
        End Set
    End Property


    Private _Phone As String ' varying(50),
    Public Property Phone() As String
        Get
            Return _Phone
        End Get
        Set(ByVal value As String)
            If value.Length > 50 Then
                Throw New Exception("Phone no puede tener más de 50 cáracteres.")
            Else
                _Phone = value
            End If
        End Set
    End Property


    Private _CreditCardType As Integer ' not null
    Public Property CreditCardType() As Integer
        Get
            Return _CreditCardType
        End Get
        Set(ByVal value As Integer)
            If value <> 0 AndAlso value = Nothing Then
                Throw New Exception("CreditCardType no puede ser nulo.")
            ElseIf IsNumeric(value) <> True Then
                Throw New Exception("CreditCardType tiene que ser númerico.")
            Else
                _CreditCardType = value
            End If
        End Set
    End Property


    Private _CreditCard As String ' varying(50) Not NULL,
    Public Property CreditCard() As String
        Get
            Return _CreditCard
        End Get
        Set(ByVal value As String)
            If value Is Nothing Then
                Throw New Exception("CreditCard no puede ser nulo.")
            ElseIf value.Length > 50 Then
                Throw New Exception("CreditCard no puede tener más de 50 cáracteres.")
            Else
                _CreditCard = value
            End If
        End Set
    End Property


    Private _CreditCardExpiration As String ' varying(50) Not NULL,
    Public Property CreditCardExpiration() As String
        Get
            Return _CreditCardExpiration
        End Get
        Set(ByVal value As String)
            If value Is Nothing Then
                Throw New Exception("CreditCardExpiration no puede ser nulo.")
            ElseIf value.Length > 50 Then
                Throw New Exception("CreditCardExpiration no puede tener más de 50 cáracteres.")
            Else
                _CreditCardExpiration = value
            End If
        End Set
    End Property


    Private _UserName As String ' varying(50) Not NULL,
    Public Property UserName() As String
        Get
            Return _UserName
        End Get
        Set(ByVal value As String)
            If value Is Nothing Then
                Throw New Exception("UserName no puede ser nulo.")
            ElseIf value.Length > 50 Then
                Throw New Exception("UserName no puede tener más de 50 cáracteres.")
            Else
                _UserName = value
            End If
        End Set
    End Property


    Private _Password As String ' varying(50) Not NULL,
    Public Property Password() As String
        Get
            Return _Password
        End Get
        Set(ByVal value As String)
            If value Is Nothing Then
                Throw New Exception("Password no puede ser nulo.")
            ElseIf value.Length > 50 Then
                Throw New Exception("Password no puede tener más de 50 cáracteres.")
            Else
                _Password = value
            End If
        End Set
    End Property


    Private _Age As UShort
    Public Property Age() As UShort

        Get
            Return _Age
        End Get
        Set(ByVal value As UShort)
            If IsNumeric(value) <> True Then
                Throw New Exception("Age tiene que ser númerico.")
            Else
                _Age = value
            End If
        End Set
    End Property


    Private _Income As Integer
    Public Property Income() As Integer
        Get
            Return _Income
        End Get
        Set(ByVal value As Integer)
            If IsNumeric(value) Then
                _Income = value
            Else
                Throw New Exception("Income tiene que ser númerico.")
            End If
        End Set
    End Property


    Private _Gender As Char ' varying(1)

    Public Property Gender() As Char
        Get
            Return _Gender
        End Get
        Set(ByVal value As Char)
            _Gender = value
        End Set
    End Property


    Public Sub New(customerId As Integer, firstName As String, lastName As String,
                   address1 As String, address2 As String, city As String, state As String,
                   zip As Integer, country As String, region As Short,
                   email As String, phone As String, creditCardType As Integer, creditCard As String,
                   creditCardExpiration As String, userName As String, password As String,
                   age As UShort, income As Integer, gender As Char)

        Me.CustomerId = customerId
        Me.FirstName = firstName
        Me.LastName = lastName
        Me.Address1 = address1
        Me.Address2 = address2
        Me.City = city
        Me.State = state
        Me.Zip = zip
        Me.Country = country
        Me.Region = region
        Me.Email = email
        Me.Phone = phone
        Me.CreditCardType = creditCardType
        Me.CreditCard = creditCard
        Me.CreditCardExpiration = creditCardExpiration
        Me.UserName = userName
        Me.Password = password
        Me.Age = age
        Me.Income = income
        Me.Gender = gender
        _ADO = New CustomersADO
    End Sub


    Public Sub New(ByRef Customer As Customers)
        Me.CustomerId = Customer.CustomerId
        Me.FirstName = Customer.FirstName
        Me.LastName = Customer.LastName
        Me.Address1 = Customer.Address1
        Me.Address2 = Customer.Address2
        Me.City = Customer.City
        Me.State = Customer.State
        Me.Zip = Customer.Zip
        Me.Country = Customer.Country
        Me.Region = Customer.Region
        Me.Email = Customer.Email
        Me.Phone = Customer.Phone
        Me.CreditCardType = Customer.CreditCardType
        Me.CreditCard = Customer.CreditCard
        Me.CreditCardExpiration = Customer.CreditCardExpiration
        Me.UserName = Customer.UserName
        Me.Password = Customer.Password
        Me.Age = Customer.Age
        Me.Income = Customer.Income
        Me.Gender = Customer.Gender
        _ADO = New CustomersADO
    End Sub

    Public Sub New()

        Me.CustomerId = -1
        Me.FirstName = "Default"
        Me.LastName = "Default"
        Me.Address1 = "Default"
        Me.Address2 = ""
        Me.City = "Default"
        Me.State = "Default"
        Me.Zip = -1
        Me.Country = "Default"
        Me.Region = -1
        Me.Email = "Default"
        Me.Phone = ""
        Me.CreditCardType = -1
        Me.CreditCard = "Default"
        Me.CreditCardExpiration = "Default"
        Me.UserName = "Default"
        Me.Password = "Default"
        Me.Age = 0
        Me.Income = 0
        Me.Gender = "M"c
        _ADO = New CustomersADO
    End Sub

    Public Sub Dispose()
        Me._CustomerId = Nothing
        Me._FirstName = Nothing
        Me._LastName = Nothing
        Me._Address1 = Nothing
        Me._Address2 = Nothing
        Me._City = Nothing
        Me._State = Nothing
        Me._Zip = Nothing
        Me._Country = Nothing
        Me._Region = Nothing
        Me._Email = Nothing
        Me._Phone = Nothing
        Me._CreditCardType = Nothing
        Me._CreditCard = Nothing
        Me._CreditCardExpiration = Nothing
        Me._UserName = Nothing
        Me._Password = Nothing
        Me._Age = Nothing
        Me._Income = Nothing
        Me._Gender = Nothing
        Me._ADO.Dispose()
    End Sub


    Protected Overrides Sub Finalize()
        Me._CustomerId = Nothing
        Me._FirstName = Nothing
        Me._LastName = Nothing
        Me._Address1 = Nothing
        Me._Address2 = Nothing
        Me._City = Nothing
        Me._State = Nothing
        Me._Zip = Nothing
        Me._Country = Nothing
        Me._Region = Nothing
        Me._Email = Nothing
        Me._Phone = Nothing
        Me._CreditCardType = Nothing
        Me._CreditCard = Nothing
        Me._CreditCardExpiration = Nothing
        Me._UserName = Nothing
        Me._Password = Nothing
        Me._Age = Nothing
        Me._Income = Nothing
        Me._Gender = Nothing
        Me._ADO.Dispose()
    End Sub

    Public Overrides Function ToString() As String
        Return "CustomerId -> " & CustomerId & ", FirstName - > " &
            FirstName & ", LastName - > " & LastName
    End Function

    ''''''''''''''''''''''''''''''''''''''''''''''''
    ' AQUI EMPIEZAN LAS ACCIONES CON LA BASE DE DATOS.
    ''''''''''''''''''''''''''''''''''''''''''''''''
    ''' <summary>
    ''' Constructor para insertar un cliente en la base de datos.
    ''' </summary>

    Private _ADO As CustomersADO

    Public Sub New(firstName As String, lastName As String,
                   address1 As String, address2 As String, city As String, state As String,
                   zip As Integer, country As String, region As Short,
                   email As String, phone As String, creditCardType As Integer, creditCard As String,
                   creditCardExpiration As String, userName As String, password As String,
                   age As UShort, income As Integer, gender As Char)

        _ADO = New CustomersADO

        Dim Sql As String = String.Format("INSERT INTO CUSTOMERS 
            ( firstName , lastName , address1 , address2 , city , state , 
            zip, country , region , email , phone ,  creditCardType ,  creditCard ,  
            creditCardExpiration , userName , password , age ,  income , gender ) 
            VALUES ('{0}' , '{1}'  , '{2}'  , '{3}'  , '{4}'  , '{5}'  , '{6}'  , '{7}' 
            , '{8}'  , '{9}' , '{10}'  , '{11}' , '{12}'  , '{13}'  , '{14}'  , '{15}' , 
            '{16}' , '{17}'  , '{18}' ) RETURNING CUSTOMERID",
            firstName, lastName, address1, address2, city, state, zip, country, region,
            email, phone, creditCardType, creditCard, creditCardExpiration,
            userName, password, age, income, gender)

        Dim CustomerId As Integer = _ADO.Insertar(Sql)

        If (CustomerId = 0) Then
            Throw New Exception("Se ha producido un error al insertar el cliente. Puede ser que este nick de cliente ya exista.")
        Else

            Me.CustomerId = CustomerId
            Me.FirstName = firstName
            Me.LastName = lastName
            Me.Address1 = address1
            Me.Address2 = address2
            Me.City = city
            Me.State = state
            Me.Zip = zip
            Me.Country = country
            Me.Region = region
            Me.Email = email
            Me.Phone = phone
            Me.CreditCardType = creditCardType
            Me.CreditCard = creditCard
            Me.CreditCardExpiration = creditCardExpiration
            Me.UserName = userName
            Me.Password = password
            Me.Age = age
            Me.Income = income
            Me.Gender = gender

        End If

    End Sub


    ''' <summary>
    ''' BORRAR EL CLIENTE ACTUAL DE LA BASE DE DATOS
    ''' </summary>
    Public Sub Borrar()

        Dim sql As String = String.Format("DELETE FROM CUSTOMERS 
                                            WHERE CUSTOMERID = '{0}'", CustomerId)

        Dim Borrado As Boolean = _ADO.Borrar(sql)

        If (Borrado = False) Then
            Throw New Exception("Se ha producido un error al borrar el cliente.")
        End If

    End Sub


    ''' <summary>
    ''' ACTUALIZA EL CLIENTE ACTUAL DE LA BASE DE DATOS
    ''' </summary>
    Public Sub Actualizar()

        Dim Sql As String = String.Format("UPDATE  CUSTOMERS SET
            firstName = '{0}' , lastName = '{1}', address1 = '{2}' , address2  = '{3}' , 
            city = '{4}', state = '{5}',    zip = '{6}', country = '{7}', region = '{8}',
            email = '{9}', phone = '{10}',  creditCardType = '{11}',  creditCard = '{12}',  
            creditCardExpiration = '{13}', userName = '{14}', password = '{15}', 
            age = '{16}',  income = '{17}', gender = '{18}'
            WHERE customerid = '{19}' ",
            FirstName, LastName, Address1, Address2, City, State, Zip, Country, Region,
            Email, Phone, CreditCardType, CreditCard, CreditCardExpiration,
            UserName, Password, Age, Income, Gender, CustomerId)


        Dim Actualizado As Boolean = _ADO.Actualizar(Sql)

        If (Actualizado = False) Then
            Throw New Exception("Se ha producido un error al actualizar el cliente.")
        End If

    End Sub

    ''' <summary>
    ''' Obtine los datos de un cliente pasandole su nick
    ''' </summary>

    Public Sub New(ByVal UserName As String)

        _ADO = New CustomersADO

        Dim Sql As String = String.Format("SELECT 
             CustomerId , firstName , lastName , address1 , coalesce(address2,'') as address2 , city , coalesce(state,'') as state , 
            zip, country , region , email , phone ,  creditCardType ,  creditCard ,  
            creditCardExpiration , userName , password , age ,  income , gender
            FROM CUSTOMERS 
            WHERE USERNAME = '{0}'", UserName)

        Dim Customer As Customers = _ADO.Obtener(Sql)

        If (Customer Is Nothing) Then
            Throw New Exception("Se ha producido un error al obtener los datos del cliente. Puede ser que este cliente no este dado de alta.")
        Else
            Me.CustomerId = Customer.CustomerId
            Me.FirstName = Customer.FirstName
            Me.LastName = Customer.LastName
            Me.Address1 = Customer.Address1
            Me.Address2 = Customer.Address2
            Me.City = Customer.City
            Me.State = Customer.State
            Me.Zip = Customer.Zip
            Me.Country = Customer.Country
            Me.Region = Customer.Region
            Me.Email = Customer.Email
            Me.Phone = Customer.Phone
            Me.CreditCardType = Customer.CreditCardType
            Me.CreditCard = Customer.CreditCard
            Me.CreditCardExpiration = Customer.CreditCardExpiration
            Me.UserName = Customer.UserName
            Me.Password = Customer.Password
            Me.Age = Customer.Age
            Me.Income = Customer.Income
            Me.Gender = Customer.Gender

        End If

    End Sub


    ''' <summary>
    ''' Obtine los datos de un cliente pasandole su id
    ''' </summary>

    Public Sub New(ByVal CustomerId As Integer)

        _ADO = New CustomersADO

        Dim Sql As String = String.Format("SELECT 
             CustomerId , firstName , lastName , address1 , coalesce(address2,'') as address2 , city , coalesce(state,'') as state , 
            zip, country , region , email , phone ,  creditCardType ,  creditCard ,  
            creditCardExpiration , userName , password , age ,  income , gender
            FROM CUSTOMERS 
            WHERE CustomerId = '{0}';", CustomerId)

        Dim Customer As Customers = _ADO.Obtener(Sql)

        If (Customer Is Nothing) Then
            Throw New Exception("Se ha producido un error al obtener los datos del cliente. Puede ser que este cliente no este dado de alta.")
        Else
            Me.CustomerId = Customer.CustomerId
            Me.FirstName = Customer.FirstName
            Me.LastName = Customer.LastName
            Me.Address1 = Customer.Address1
            Me.Address2 = Customer.Address2
            Me.City = Customer.City
            Me.State = Customer.State
            Me.Zip = Customer.Zip
            Me.Country = Customer.Country
            Me.Region = Customer.Region
            Me.Email = Customer.Email
            Me.Phone = Customer.Phone
            Me.CreditCardType = Customer.CreditCardType
            Me.CreditCard = Customer.CreditCard
            Me.CreditCardExpiration = Customer.CreditCardExpiration
            Me.UserName = Customer.UserName
            Me.Password = Customer.Password
            Me.Age = Customer.Age
            Me.Income = Customer.Income
            Me.Gender = Customer.Gender

        End If

    End Sub

End Class