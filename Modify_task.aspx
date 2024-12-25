<%@ Page Title="" Language="C#" MasterPageFile="~/Site2.Master" AutoEventWireup="true" CodeBehind="Modify_task.aspx.cs" Inherits="School.Modify_task" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <p>
        Редактирование задания</p>
    <p>
        &nbsp;</p>
    <p>
        <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" onSelectedIndexChanged="GridView1_SelectedIndexChanged" DataKeyNames="assignment_id" >
            <Columns>
                <asp:CommandField ShowSelectButton="True" />
                <asp:BoundField DataField="assignment_id" HeaderText="assignment_id" InsertVisible="False" ReadOnly="True" SortExpression="assignment_id" Visible="False" />
                <asp:BoundField DataField="subject_name" HeaderText="Название предмета" SortExpression="subject_name" />
                <asp:BoundField DataField="assignment_name" HeaderText="Название задания" SortExpression="assignment_name" />
                <asp:BoundField DataField="task_description" HeaderText="Описание задания" SortExpression="task_description" />
                <asp:BoundField DataField="deadline" HeaderText="Дедлайн" SortExpression="deadline" />
                <asp:BoundField DataField="max_score" HeaderText="Максимальная оценка" SortExpression="max_score" />
            </Columns>
        </asp:GridView>
        <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:School_newConnectionString %>" SelectCommand="SELECT * FROM [Assignment]"></asp:SqlDataSource>
    </p>
    <p>
        <asp:DetailsView ID="DetailsView1" runat="server" AutoGenerateRows="False" Height="50px" Width="125px">
            <Fields>
                <asp:BoundField DataField="subject_name" HeaderText="Название предмета" SortExpression="subject_name" />
                <asp:BoundField DataField="task_description" HeaderText="Описание задания" SortExpression="task_description" />
                <asp:BoundField DataField="deadline" HeaderText="Дедлайн" SortExpression="deadline" />
                <asp:BoundField DataField="max_score" HeaderText="Максимальная оценка" SortExpression="max_score" />
            </Fields>
        </asp:DetailsView>
        <asp:SqlDataSource ID="SqlDataSource2" runat="server" ConnectionString="<%$ ConnectionStrings:School_newConnectionString %>" SelectCommand="SELECT [task_description], [deadline], [max_score], [subject_name] FROM [Assignment]"></asp:SqlDataSource>
    </p>
    <p>
        <table style="width:100%;">
            <tr>
                <td style="width: 338px">
                    <asp:Label ID="Label4" runat="server" Text="Изменить название задания"></asp:Label>
                </td>
                <td>
                    <asp:TextBox ID="TextBox3" runat="server"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td class="auto-style15" style="width: 338px">
                    <asp:Label ID="Label5" runat="server" Text="Изменить описание задания"></asp:Label>
                </td>
                <td class="auto-style15">
                    <asp:TextBox ID="TextBox4" runat="server"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td style="width: 338px">
                    <asp:Label ID="Label6" runat="server" Text="Изменить дедлайн"></asp:Label>
                </td>
                <td>
                    <asp:TextBox ID="TextBox5" runat="server"></asp:TextBox>
                    <br />
                    <asp:Calendar ID="Calendar1" runat="server" onSelectionChanged="Calendar1_SelectionChanged"></asp:Calendar>
                </td>
            </tr>
            <tr>
                <td style="width: 338px">
                    <asp:Label ID="Label7" runat="server" Text="Изменить максимальную оценку"></asp:Label>
                </td>
                <td>
                    <asp:TextBox ID="TextBox6" runat="server"></asp:TextBox>
                </td>
            </tr>
        </table>
    </p>
    <p>
        <asp:Button ID="Button7" runat="server" onClick="Button7_Click" Text="Изменить информацию" />
        <asp:Label ID="Label8" runat="server" Text=""></asp:Label>
    </p>
</asp:Content>
