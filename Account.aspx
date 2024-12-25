<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="Account.aspx.cs" Inherits="School.Account" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:Label ID="Label4" runat="server" Text="Личный кабинет"></asp:Label>
    <br />
    <br />
    <asp:Label ID="Label5" runat="server" Text="Мои отчеты"></asp:Label>
    <br />
    <br />
    <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" DataKeyNames="report_id">
        <Columns>
            <asp:BoundField DataField="report_id" HeaderText="report_id" InsertVisible="False" ReadOnly="True" SortExpression="report_id" Visible="False" />
            <asp:BoundField DataField="pupil_id" HeaderText="pupil_id" SortExpression="pupil_id" Visible="False" />
            <asp:BoundField DataField="assignment_id" HeaderText="Номер задания" SortExpression="assignment_id" />
            <asp:BoundField DataField="subject_name" HeaderText="Название предмета" SortExpression="subject_name" />
            <asp:BoundField DataField="assignment_name" HeaderText="Название задания" SortExpression="assignment_name" />
            <asp:BoundField DataField="status" HeaderText="Статус" SortExpression="status" />
        </Columns>
    </asp:GridView>
    <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="Data Source=DESKTOP-ET5055J\SQLEXPRESS;Initial Catalog=School_new;Integrated Security=True;Trust Server Certificate=True" ProviderName="System.Data.SqlClient" SelectCommand="SELECT [report_id], [assignment_id], [pupil_id], [assignment_name], [status], [subject_name] FROM [Report]"></asp:SqlDataSource>
    <br />
    <asp:Label ID="Label9" runat="server" Text="Изменение данных"></asp:Label>
    <br />
    <table style="width:100%;">
        <tr>
            <td>
                <asp:Label ID="Label6" runat="server" Text="Логин"></asp:Label>
            </td>
            <td>
                <asp:TextBox ID="TextBox3" runat="server"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td>
                <asp:Label ID="Label7" runat="server" Text="Пароль"></asp:Label>
            </td>
            <td>
                <asp:TextBox ID="TextBox4" runat="server"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td style="height: 23px">
                <asp:Button ID="Button7" runat="server" OnClick="Button7_Click" Text="Обновить" />
            </td>
            <td style="height: 23px">
                <asp:Label ID="Label10" runat="server" Text=""></asp:Label>
            </td>
        </tr>
    </table>
    <br />
</asp:Content>
