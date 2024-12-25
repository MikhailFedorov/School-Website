<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="Registration.aspx.cs" Inherits="School.Registration" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <table style="width: 56%; height: 604px;">
        <tr>
            <td style="width: 443px">
                <asp:Label ID="Label2" runat="server" Text="Регистрация"></asp:Label>
            </td>
            <td>
                <asp:Label ID="Label3" runat="server" Text="SuccessCheck"></asp:Label>
            </td>
        </tr>
        <tr>
            <td style="width: 443px">
                <asp:Label ID="Label4" runat="server" Text="Имя"></asp:Label>
            </td>
            <td>
                <asp:TextBox ID="TextBox1" runat="server"></asp:TextBox>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="TextBox1" EnableClientScript="False" ErrorMessage="Имя обязательно для заполнения"></asp:RequiredFieldValidator>
            </td>
        </tr>
        <tr>
            <td style="width: 443px">
                <asp:Label ID="Label5" runat="server" Text="Фамилия"></asp:Label>
            </td>
            <td>
                <asp:TextBox ID="TextBox2" runat="server"></asp:TextBox>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="TextBox2" EnableClientScript="False" ErrorMessage="Фамилия обязательна для заполнения"></asp:RequiredFieldValidator>
            </td>
        </tr>
        <tr>
            <td style="width: 443px">
                <asp:Label ID="Label6" runat="server" Text="Отчество"></asp:Label>
            </td>
            <td>
                <asp:TextBox ID="TextBox3" runat="server"></asp:TextBox>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="TextBox3" EnableClientScript="False" ErrorMessage="Отчество обязательно для заполнения"></asp:RequiredFieldValidator>
            </td>
        </tr>
        <tr>
            <td style="width: 443px">
                <asp:Label ID="Label7" runat="server" Text="Телефон"></asp:Label>
            </td>
            <td>
                <asp:TextBox ID="TextBox4" runat="server" TextMode="Number"></asp:TextBox>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ControlToValidate="TextBox4" EnableClientScript="False" ErrorMessage="Телефон обязателен к заполнению"></asp:RequiredFieldValidator>
            </td>
        </tr>
        <tr>
            <td style="width: 443px">
                <asp:Label ID="Label8" runat="server" Text="Логин"></asp:Label>
            </td>
            <td>
                <asp:TextBox ID="TextBox5" runat="server"></asp:TextBox>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" ControlToValidate="TextBox5" EnableClientScript="False" ErrorMessage="Логин обязателен к заполнению"></asp:RequiredFieldValidator>
            </td>
        </tr>
        <tr>
            <td style="width: 443px">
                <asp:Label ID="Label9" runat="server" Text="Пароль"></asp:Label>
            </td>
            <td>
                <asp:TextBox ID="TextBox6" runat="server" TextMode="Password"></asp:TextBox>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator6" runat="server" ControlToValidate="TextBox6" EnableClientScript="False" ErrorMessage="Пароль обязателен к заполнению"></asp:RequiredFieldValidator>
            </td>
        </tr>
        <tr>
            <td style="width: 443px">
                <asp:Label ID="Label10" runat="server" Text="Роль"></asp:Label>
            </td>
            <td>
                <asp:DropDownList ID="DropDownList1" runat="server">
                    <asp:ListItem Value="pupil">Ученик</asp:ListItem>
                    <asp:ListItem Value="teacher">Учитель</asp:ListItem>
                </asp:DropDownList>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator7" runat="server" ControlToValidate="DropDownList1" EnableClientScript="False" ErrorMessage="Выберите роль"></asp:RequiredFieldValidator>
            </td>
        </tr>
        <tr>
            <td style="width: 443px">
                <asp:Button ID="Button4" runat="server" OnClick="Button4_Click" Text="Зарегистрироваться" />
            </td>
            <td>&nbsp;</td>
        </tr>
    </table>
</asp:Content>
