<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="FirstPage.aspx.cs" Inherits="BasicWebForm.FirstPage" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
<link href="https://cdn.jsdelivr.net/npm/bootstrap@5.0.2/dist/css/bootstrap.min.css" rel="stylesheet" integrity="sha384-EVSTQN3/azprG1Anm3QDgpJLIm9Nao0Yz1ztcQTwFspd3yD65VohhpuuCOmLASjC" crossorigin="anonymous"/>
<script src="https://cdn.jsdelivr.net/npm/bootstrap@5.0.2/dist/js/bootstrap.bundle.min.js" integrity="sha384-MrcW6ZMFYlzcLA8Nl+NtUVF0sA7MsXsP1UyJoMp4YLEuNSfAP+JcXn/tWtIaxVXM" crossorigin="anonymous"></script>
<link href="Assets/css/style.css" rel="stylesheet" type="text/css" />
<script src="Assets/js/validation.js"></script>

</head>
<body>
    <div class="card general-warpper">
        <div class="card-body">
    <form id="form1" runat="server" class="row g-3 needs-validation" novalidate="novalidate">
          <div class="col-md-6">
            <label for="Name" class="form-label">Nombre Completo</label>
              <asp:TextBox ID="Name" runat="server" CssClass="form-control" required="required" type="text"></asp:TextBox>
          </div>
          <div class="col-md-6">
            <label for="Document" class="form-label">Número de Documento</label>
            <asp:TextBox ID="Document" runat="server" CssClass="form-control" required="required" type="number"></asp:TextBox>
          </div>
          <div class="col-md-12">
            <label for="Address" class="form-label">Dirección</label>
              <asp:TextBox ID="Address" runat="server" CssClass="form-control" required="required" type="text"></asp:TextBox>
          </div>
 
          <div class="col-12">
            <asp:Button ID="EnviarButton" CssClass="btn btn-primary" runat="server" Text="Submit form" OnClientClick="return CheckForm();" OnClick="EnviarButton_Click"/>
          </div>
    </form>
        </div>
    </div>
</body>
</html>
