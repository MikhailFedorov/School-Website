<%@ Page Title="" Language="C#" MasterPageFile="~/Site2.Master" AutoEventWireup="true" CodeBehind="Upload_task.aspx.cs" Inherits="School.Upload_task" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <table style="width:100%;">
        <tr>
            <td class="auto-style9" style="width: 191px">
                &nbsp;</td>
            <td style="width: 630px">
                &nbsp;</td>
        </tr>
        <tr>
            <td class="auto-style9" style="width: 191px">
                <asp:Label ID="Label5" runat="server" Text="Введите название задания"></asp:Label>
            </td>
            <td style="width: 630px">
                <asp:TextBox ID="TextBox3" runat="server" TextMode="MultiLine"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td class="auto-style15" style="width: 191px">
                <asp:Label ID="Label6" runat="server" Text="Введите описание задания"></asp:Label>
            </td>
            <td class="auto-style15" style="width: 630px">
                <asp:TextBox ID="TextBox4" runat="server" TextMode="MultiLine"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td class="auto-style15" style="width: 191px">
                <asp:Label ID="Label7" runat="server" Text="Введите максимальную оценку"></asp:Label>
            </td>
            <td class="auto-style15" style="width: 630px">
                <asp:TextBox ID="TextBox5" runat="server"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td class="auto-style9" style="width: 191px">
                <asp:Label ID="Label8" runat="server" Text="Введите дату дедлайна"></asp:Label>
            </td>
            <td style="width: 630px">
                <asp:TextBox ID="TextBox6" runat="server"></asp:TextBox>
                <br />
                <asp:Calendar ID="Calendar1" runat="server" onSelectionChanged="Calendar1_SelectionChanged"></asp:Calendar>
                <br />
                <asp:Button ID="Button7" runat="server" onClick="Button7_Click" Text="Добавить задание" />
                &nbsp;&nbsp;
                <asp:Label ID="Label10" runat="server" Text=""></asp:Label>
                <br />
            </td>
        </tr>
    </table>
    <br />
    <br />
    <asp:Label ID="Label9" runat="server" Text="Текущие задания по предмету"></asp:Label>
    <br />
    <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False">
        <Columns>
            <asp:BoundField DataField="assignment_name" HeaderText="assignment_name" SortExpression="assignment_name" />
            <asp:BoundField DataField="task_description" HeaderText="task_description" SortExpression="task_description" />
            <asp:BoundField DataField="deadline" HeaderText="deadline" SortExpression="deadline" />
            <asp:BoundField DataField="max_score" HeaderText="max_score" SortExpression="max_score" />
            <asp:BoundField DataField="subject_name" HeaderText="subject_name" SortExpression="subject_name" />
        </Columns>
    </asp:GridView>
    <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:School_newConnectionString %>" SelectCommand="SELECT [assignment_name], [task_description], [deadline], [max_score], [subject_name] FROM [Assignment]"></asp:SqlDataSource>
</asp:Content>
