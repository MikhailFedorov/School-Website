<%@ Page Title="" Language="C#" MasterPageFile="~/Site2.Master" AutoEventWireup="true" CodeBehind="Check_reports.aspx.cs" Inherits="School.Check_reports" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <br />
    <br />
    <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" DataKeyNames="report_id" onSelectedIndexChanged="GridView1_SelectedIndexChanged">
        <Columns>
            <asp:CommandField ShowSelectButton="True" />
            <asp:BoundField DataField="report_id" HeaderText="Номер отчета" InsertVisible="False" ReadOnly="True" SortExpression="report_id" />
            <asp:BoundField DataField="assignment_id" HeaderText="Номер задания" SortExpression="assignment_id" />
            <asp:BoundField DataField="pupil_id" HeaderText="Номер ученика" SortExpression="pupil_id" />
            <asp:BoundField DataField="status" HeaderText="Статус" SortExpression="status" />
            <asp:BoundField DataField="assignment_name" HeaderText="Название задания" SortExpression="assignment_name" />
            <asp:BoundField DataField="subject_name" HeaderText="Название предмета" SortExpression="subject_name" />
            <asp:BoundField DataField="report_text" HeaderText="Текст отчета" SortExpression="report_text" />
            <asp:BoundField DataField="score" HeaderText="Оценка" SortExpression="score" />
            <asp:BoundField DataField="comment" HeaderText="Комментарий учителя" SortExpression="comment" />
        </Columns>
    </asp:GridView>
    <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:School_newConnectionString %>" SelectCommand="SELECT * FROM [Report]"></asp:SqlDataSource>
    <asp:DetailsView ID="DetailsView1" runat="server" AutoGenerateRows="False"  Height="50px" Width="125px">
        <Fields>
            <asp:BoundField DataField="subject_name" HeaderText="subject_name" SortExpression="subject_name" />
            <asp:BoundField DataField="assignment_name" HeaderText="assignment_name" SortExpression="assignment_name" />
            <asp:BoundField DataField="report_text" HeaderText="report_text" SortExpression="report_text" />
        </Fields>
    </asp:DetailsView>
    <asp:SqlDataSource ID="SqlDataSource2" runat="server" ConnectionString="<%$ ConnectionStrings:School_newConnectionString %>" SelectCommand="SELECT [subject_name], [assignment_name], [report_text] FROM [Report]"></asp:SqlDataSource>
    <br />
    <table style="width:100%;">
        <tr>
            <td class="auto-style15" style="width: 239px">
                <asp:Label ID="Label4" runat="server" Text="Статус"></asp:Label>
            </td>
            <td class="auto-style15">
                <asp:DropDownList ID="DropDownList2" runat="server" onSelectedIndexChanged="DropDownList2_SelectedIndexChanged" AutoPostBack="True">
                    <asp:ListItem>Выберите вариант</asp:ListItem>
                    <asp:ListItem>Принято</asp:ListItem>
                    <asp:ListItem>Отклонено</asp:ListItem>
                </asp:DropDownList>
            </td>
        </tr>
        <tr>
            <td class="auto-style9" style="width: 239px">
                <asp:Label ID="Label5" runat="server" Text="Оценка"></asp:Label>
            </td>
            <td>
                <asp:TextBox ID="TextBox3" runat="server"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td class="auto-style9" style="width: 239px">
                <asp:Label ID="Label6" runat="server" Text="Комментарий"></asp:Label>
            </td>
            <td>
                <asp:TextBox ID="TextBox4" runat="server"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td class="auto-style9" style="width: 239px">
                <asp:Button ID="Button7" runat="server" onClick="Button7_Click" Text="Применить" />
            </td>
            <td>
                <asp:Label ID="Label7" runat="server" Text=""></asp:Label>
            </td>
        </tr>
    </table>
</asp:Content>
