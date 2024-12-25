<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="Timetable.aspx.cs" Inherits="School.Timetable" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <p>
        <asp:DropDownList ID="DropDownList1" runat="server" AutoPostBack="True" DataTextField="day_name" DataValueField="day_name">
        </asp:DropDownList>
    </p>
    <p>
        <asp:DropDownList ID="DropDownList2" runat="server" AutoPostBack="True" DataTextField="subject_name" DataValueField="subject_name">
        </asp:DropDownList>
    </p>
    <p>
        <asp:Button ID="Button4" runat="server" Text="Поиск по дню" OnClick="Button4_Click"/>
        <asp:Button ID="Button5" runat="server" Text="Поиск по предмету" OnClick="Button5_Click"/>
        <asp:Button ID="Button6" runat="server" Text="Поиск по дню и по предмету" OnClick="Button6_Click"/>
        <asp:Button ID="Button7" runat="server" Text="Сброс" OnClick="Button7_Click"/>
    </p>
    <p>
        <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" DataKeyNames="timetable_id"  OnSelectedIndexChanged="GridView1_SelectedIndexChanged"  AllowSorting="True">
            <Columns>
                <asp:CommandField ShowSelectButton="True" />
                <asp:BoundField DataField="timetable_id" HeaderText="timetable_id" InsertVisible="False" ReadOnly="True" SortExpression="timetable_id" Visible="False" />
                <asp:BoundField DataField="weekday_name" HeaderText="День недели" SortExpression="weekday_name" />
                <asp:BoundField DataField="subject_name" HeaderText="Название предмета" SortExpression="subject_name" />
                <asp:BoundField DataField="lesson_number" HeaderText="Номер урока" SortExpression="lesson_number" />
                <asp:BoundField DataField="lesson_begin" HeaderText="Начало урока" SortExpression="lesson_begin" />
                <asp:BoundField DataField="lesson_end" HeaderText="Конец урока" SortExpression="lesson_end" />
                <asp:BoundField DataField="teacher_name" HeaderText="Имя учителя" SortExpression="teacher_name" />
                <asp:BoundField DataField="class_name" HeaderText="Класс" SortExpression="class_name" />
            </Columns>
        </asp:GridView>
        <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:School_newConnectionString %>" SelectCommand="SELECT * FROM [Timetable]"></asp:SqlDataSource>
    </p>
    <p>
        <asp:DetailsView ID="DetailsView1" runat="server" AutoGenerateRows="False"  Height="50px" Width="125px" DataKeyNames="timetable_id">
            <Fields>
                <asp:CommandField ShowSelectButton="True" />
                <asp:BoundField DataField="timetable_id" HeaderText="timetable_id" InsertVisible="False" ReadOnly="True" SortExpression="timetable_id" />
                <asp:BoundField DataField="weekday_name" HeaderText="weekday_name" SortExpression="weekday_name" />
                <asp:BoundField DataField="lesson_number" HeaderText="lesson_number" SortExpression="lesson_number" />
                <asp:BoundField DataField="lesson_begin" HeaderText="lesson_begin" SortExpression="lesson_begin" />
                <asp:BoundField DataField="lesson_end" HeaderText="lesson_end" SortExpression="lesson_end" />
                <asp:BoundField DataField="subject_name" HeaderText="subject_name" SortExpression="subject_name" />
                <asp:BoundField DataField="teacher_name" HeaderText="teacher_name" SortExpression="teacher_name" />
                <asp:BoundField DataField="class_name" HeaderText="class_name" SortExpression="class_name" />
            </Fields>
        </asp:DetailsView>
</asp:Content>
