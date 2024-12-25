<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="Assignments.aspx.cs" Inherits="School.Assignments" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <p>
    Задания</p>
    <p>
        <asp:DropDownList ID="DropDownList1" runat="server" AutoPostBack="True"  DataTextField="subject_name" DataValueField="subject_name" OnSelectedIndexChanged="DropDownList1_SelectedIndexChanged" Width="69px">
        </asp:DropDownList>
        <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:School_newConnectionString %>" OnSelecting="SqlDataSource1_Selecting" SelectCommand="SELECT * FROM [Assignment] WHERE ([subject_name] LIKE '%' + @subject_name + '%')">
            <SelectParameters>
                <asp:SessionParameter Name="subject_name" SessionField="IDS" Type="String" />
            </SelectParameters>
        </asp:SqlDataSource>
    </p>
    <p>
        <asp:GridView ID="GridView1" runat="server"  AllowSorting="True" AutoGenerateColumns="False" DataKeyNames="assignment_id" OnSelectedIndexChanged="GridView1_SelectedIndexChanged">
            <Columns>
                <asp:CommandField ShowSelectButton="True" />
                <asp:BoundField DataField="subject_name" HeaderText="Название предмета" SortExpression="subject_name" />
                <asp:BoundField DataField="assignment_id" HeaderText="assignment_id" InsertVisible="False" ReadOnly="True" SortExpression="assignment_id" Visible="False" />
                <asp:BoundField DataField="assignment_name" HeaderText="Задание" SortExpression="assignment_name" />
                <asp:BoundField DataField="task_description" HeaderText="Описание задания" SortExpression="task_description" />
                <asp:BoundField DataField="deadline" HeaderText="Дедлайн" SortExpression="deadline" />
                <asp:BoundField DataField="max_score" HeaderText="Максимальный балл" SortExpression="max_score" />
            </Columns>
        </asp:GridView>
        <asp:SqlDataSource ID="SqlDataSource2" runat="server" ConnectionString="<%$ ConnectionStrings:School_newConnectionString %>" OnSelecting="SqlDataSource2_Selecting" SelectCommand="SELECT * FROM [Assignment]">
            <SelectParameters>
                <asp:SessionParameter Name="subject_name" SessionField="IDG" Type="String" />
            </SelectParameters>
        </asp:SqlDataSource>
    </p>
    <p>
        <asp:DetailsView ID="DetailsView1" runat="server" AutoGenerateRows="False" DataKeyNames="assignment_id"  Height="65px" Width="125px">
            <Fields>
                <asp:BoundField DataField="assignment_id" HeaderText="assignment_id" InsertVisible="False" ReadOnly="True" SortExpression="assignment_id" />
                <asp:BoundField DataField="assignment_name" HeaderText="assignment_name" SortExpression="assignment_name" />
                <asp:BoundField DataField="task_description" HeaderText="task_description" SortExpression="task_description" />
                <asp:BoundField DataField="deadline" HeaderText="deadline" SortExpression="deadline" />
                <asp:BoundField DataField="max_score" HeaderText="max_score" SortExpression="max_score" />
                <asp:BoundField DataField="subject_name" HeaderText="subject_name" SortExpression="subject_name" />
            </Fields>
        </asp:DetailsView>
    </p>
    <p>
        <asp:TextBox ID="TextBox3" runat="server"></asp:TextBox>
    </p>
    <p>
        <asp:FileUpload ID="FileUpload1" runat="server" />
    </p>
    <p>
        <asp:Button ID="Button7" runat="server" OnClick="Button7_Click" Text="Загрузить отчет" />
        <asp:SqlDataSource ID="SqlDataSource3" runat="server" ConnectionString="<%$ ConnectionStrings:School_newConnectionString %>" SelectCommand="SELECT * FROM [Assignment] WHERE ([assignment_id] = @assignment_id)">
            <SelectParameters>
                <asp:SessionParameter Name="assignment_id" SessionField="IDG" Type="Int32" />
            </SelectParameters>
        </asp:SqlDataSource>
        <asp:Label ID="Label4" runat="server" Text=""></asp:Label>
    </p>
</asp:Content>
