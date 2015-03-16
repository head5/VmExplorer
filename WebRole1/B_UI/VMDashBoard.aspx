<%@ Page Title="" Language="C#" MasterPageFile="~/B_UI/Detail.Master" AutoEventWireup="true" CodeBehind="VMDashBoard.aspx.cs" Inherits="WebRole.B_UI.VMDashBoard" %>
<%--<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>--%>
<asp:Content ID="Content2" ContentPlaceHolderID="DetailContent" runat="server">
    <asp:Table ID="Table1" runat="server" BorderWidth="0" Height="200px">
        <asp:TableHeaderRow>
            <asp:TableHeaderCell ColumnSpan="4" BorderWidth="0">
                <h2><u>VM Dashboard&nbsp;</u></h2>
            </asp:TableHeaderCell>
        </asp:TableHeaderRow>
        <asp:TableRow>
            <asp:TableCell HorizontalAlign="Left" BorderWidth="0">
                <h6>VM Request Status:</h6>
            </asp:TableCell>
        </asp:TableRow>
        <asp:TableRow>
            <asp:TableCell ColumnSpan="3">
            <asp:TableCell>
                Status Type: </asp:TableCell><asp:DropDownList ID="ddStatusTypes" runat="server" AutoPostBack="true" OnSelectedIndexChanged="ddStatusTypes_SelectedIndexChanged"></asp:DropDownList>
            </asp:TableCell>
        </asp:TableRow>
        <asp:TableRow>
            <asp:TableCell ColumnSpan="4">
                <asp:GridView ID="gvRequests" runat="server" AllowPaging="true" AllowSorting="true" AutoGenerateColumns="false" DataKeyNames="ID"
                    BorderStyle="Solid" BorderWidth="1" BorderColor="SteelBlue" CellPadding="4" OnRowDeleting="gvRequests_RowDeleting"
                    OnRowDataBound="gvRequests_RowDataBound" OnPageIndexChanging="gvRequests_PageIndexChanging" OnSorting="gvRequests_Sorting">
                    <Columns>
                        <asp:BoundField DataField="ID" Visible="false" />
                        <asp:BoundField DataField="VMName" HeaderText="VM_Name" ReadOnly="true" SortExpression="VMName" />
                        <asp:BoundField DataField="OS" HeaderText="OS Image for VM" ReadOnly="true" SortExpression="OS" ControlStyle-Width="5" />
                        <asp:BoundField DataField="Size" HeaderText="Size" ReadOnly="true" SortExpression="Size" />
                        <asp:BoundField DataField="Location" HeaderText="Location" ReadOnly="true" />
                        <asp:BoundField DataField="Status" HeaderText="Status" ReadOnly="true" SortExpression="Status" />
                        <asp:CommandField ShowDeleteButton="true" HeaderText="Cancel" DeleteText="Cancel" />
                    </Columns>
                    <RowStyle BorderWidth="1" BorderStyle="Double" BorderColor="SteelBlue" />
                    <PagerStyle BackColor="#99CCCC" ForeColor="#003399" HorizontalAlign="Left" />
                    <FooterStyle BackColor="#003399" ForeColor="#003399" />
                    <HeaderStyle BackColor="#003399" Font-Bold="True" ForeColor="#CCCCFF" Font-Size="Small" />
                </asp:GridView>
            </asp:TableCell>
        </asp:TableRow>
        <asp:TableRow>
            <asp:TableCell ColumnSpan="4">
                <hr style="fill:ActiveBorder" />
            </asp:TableCell>
        </asp:TableRow>
        <asp:TableRow>
            <asp:TableCell ColumnSpan="3" BorderWidth="0">
                </asp:TableCell>
            <asp:TableCell HorizontalAlign="Right" BorderWidth="0">
                <asp:Button runat="server" ID="btnCreateVM" Text="Create New VM" OnClick="btnCreateVM_Click" />
            </asp:TableCell>
        </asp:TableRow>
    </asp:Table>
</asp:Content>
