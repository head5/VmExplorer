<%@ Page Title="" Language="C#" MasterPageFile="~/B_UI/Detail.Master" AutoEventWireup="true" CodeBehind="AdminVMDashBoard.aspx.cs" Inherits="WebRole.B_UI.AdminVMDashBoard" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="DetailContent" runat="server">
    <p dir="auto">
        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</p>
    <p dir="auto">
        &nbsp;</p>
    <h2><u>Pending Requests&nbsp;</u></h2>
    <p dir="auto">
        <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" DataKeyNames="MId" DataSourceID="SqlDataSource1" RowStyle-BorderWidth="1" CellPadding="3" GridLines="Both" BorderWidth="5px" BackColor="White" BorderColor="White" BorderStyle="Ridge" CellSpacing="1">
            <Columns>
                <asp:BoundField DataField="MId" HeaderText="MId" ReadOnly="True" SortExpression="MId" />
                <asp:BoundField DataField="Domain" HeaderText="Domain" SortExpression="Domain" />
                <asp:BoundField DataField="VMName" HeaderText="VMName" SortExpression="VMName" />
                <asp:BoundField DataField="Image_Name" HeaderText="Image_Name" SortExpression="Image_Name" />
                <asp:BoundField DataField="Size" HeaderText="Size" SortExpression="Size" />
                <asp:BoundField DataField="Status" HeaderText="Status" SortExpression="Status" />
                <asp:TemplateField>
                    <ItemTemplate>
                        <b><asp:LinkButton ID="Reject" Text="Reject" runat="server" /> </b>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField>
                    <ItemTemplate>                                                                                         
                       <b> <asp:LinkButton ID="CreateVm" Text="CreateVM" runat="server" Width="97px" OnClick="CreateVm_Click"/></b>
                    </ItemTemplate>
                </asp:TemplateField>

            </Columns>
            <FooterStyle BackColor="#C6C3C6" ForeColor="Black" />
            <HeaderStyle BackColor="#4A3C8C" Font-Bold="True" ForeColor="#E7E7FF" />
            <PagerStyle BackColor="#C6C3C6" ForeColor="Black" HorizontalAlign="Right" />

<RowStyle BorderWidth="2px" BackColor="#DEDFDE" ForeColor="Black"></RowStyle>
            <SelectedRowStyle BackColor="#9471DE" ForeColor="White" Font-Bold="True" />
            <SortedAscendingCellStyle BackColor="#F1F1F1" />
            <SortedAscendingHeaderStyle BackColor="#594B9C" />
            <SortedDescendingCellStyle BackColor="#CAC9C9" />
            <SortedDescendingHeaderStyle BackColor="#33276A" />
        </asp:GridView>
        <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:DBCon %>" SelectCommand="SELECT u.MId,u.Domain,r.VMName, r.Image_Name, i.Name as Size,   s.Status
FROM VM_Request r
JOIN Users u
ON r.Mid = u.MId
JOIN VM_Instance_Size i
ON r.VM_Instance_Size_Id = i.Id
JOIN VM_Request_StatusUpdate su
ON r.Request_Id = su.Request_Id
JOIN VM_Request_Status s
ON su.VM_Request_Status_Id = s.Id
WHERE s.Status = 'Pending'"></asp:SqlDataSource>
        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
    </p>
    <p dir="auto">
        <asp:TextBox ID="TextBox1" runat="server" Height="90px" TextMode="MultiLine" Width="530px"></asp:TextBox>
    </p>
    <p dir="auto">
        &nbsp;</p>
    <p>
    </p>
</asp:Content>
