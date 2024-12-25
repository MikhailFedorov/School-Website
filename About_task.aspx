<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="About_task.aspx.cs" Inherits="School.About_task" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:Label ID="Label4" runat="server" Text="Отчет успешно загружен!"></asp:Label>
    <br />
    <br />
    <asp:DetailsView ID="DetailsView1" runat="server" AutoGenerateRows="False" DataKeyNames="report_id" Height="50px" Width="125px">
        <Fields>
            <asp:BoundField DataField="report_id" HeaderText="report_id" InsertVisible="False" ReadOnly="True" SortExpression="report_id" Visible="False" />
            <asp:BoundField DataField="assignment_id" HeaderText="Номер задания" SortExpression="assignment_id" />
            <asp:BoundField DataField="pupil_id" SortExpression="pupil_id" Visible="False" HeaderText="pupil_id" />
            <asp:BoundField DataField="subject_name" HeaderText="Название предмета" SortExpression="subject_name" />
            <asp:BoundField DataField="assignment_name" HeaderText="Название задания" SortExpression="assignment_name" />
            <asp:BoundField DataField="report_text" HeaderText="Текст отчета" SortExpression="report_text" />
            <asp:BoundField DataField="status" HeaderText="Статус" SortExpression="status" />
            <asp:BoundField DataField="attached_file" HeaderText="Файл отчета" SortExpression="attached_file" />
        </Fields>
    </asp:DetailsView>
    <asp:SqlDataSource ID="SqlDataSource2" runat="server" ConnectionString="<%$ ConnectionStrings:School_newConnectionString %>" SelectCommand="SELECT * FROM [Report]"></asp:SqlDataSource>
    </asp:Content>
