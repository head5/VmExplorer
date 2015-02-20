<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="SignIn.aspx.cs" Inherits="WebRole._Default" %>

<asp:Content runat="server" ID="FeaturedContent" ContentPlaceHolderID="FeaturedContent">
    <section class="featured">
        <div class="content-wrapper">
            <hgroup class="title">
                <h1>VM Explorer</h1></br>
                <h2>&nbsp&nbsp&nbsp&nbsp Create your own VM and enjoy cloud capabilities.</h2>
            </hgroup>
            <%--<p>
                <a href="http://forums.asp.net/18.aspx" title="ASP.NET Forum">our forums</a>.
            </p>--%>
        </div>
    </section>
</asp:Content>
<asp:Content runat="server" ID="BodyContent" ContentPlaceHolderID="MainContent"
    defaultbutton="btnSubmit" defaultfocus="txtUserID">
    <div id="logInTable" style="align-content:center">
        <asp:Table ID="tblSignIN" runat="server" HorizontalAlign="Center">
            <asp:TableHeaderRow>
                <asp:TableCell HorizontalAlign="Left" >
                        <h3>Sign In</h3>
                    </asp:TableCell>
                <asp:TableCell ColumnSpan="3"></asp:TableCell>
                </asp:TableHeaderRow>
            <asp:TableRow>
                <asp:TableCell ></asp:TableCell>
                <asp:TableCell><%-- BorderWidth="1">--%>
                    User ID :
                </asp:TableCell>
                <asp:TableCell ColumnSpan="2"><%-- BorderWidth="1">--%>
                    <asp:TextBox ID="txtUserID" runat="server" Width="250" TabIndex="5"></asp:TextBox>
                </asp:TableCell>
            </asp:TableRow>
            <asp:TableRow>
                <asp:TableCell ></asp:TableCell>
                <asp:TableCell><%-- BorderWidth="1">--%>
                    Password :
                </asp:TableCell>
                <asp:TableCell ColumnSpan="2"><%-- BorderWidth="1">--%>
                    <asp:TextBox ID="txtPassword" runat="server" Width="250" TextMode="Password" TabIndex="6"></asp:TextBox>
                </asp:TableCell>
            </asp:TableRow>
            <asp:TableRow HorizontalAlign="Center">
                <asp:TableCell ></asp:TableCell>
                <asp:TableCell ></asp:TableCell>
                <asp:TableCell><%-- BorderWidth="1">--%>
                    <asp:Button ID="btnClear" runat="server" Text="Clear" TabIndex="8" Width="75" OnClick="btnClear_Click" />
                </asp:TableCell>
                <asp:TableCell><%-- BorderWidth="1">--%>
                    <asp:Button ID="btnSubmit" runat="server" Text="Submit" TabIndex="7" Width="75" OnClick="btnSubmit_Click" />
                </asp:TableCell>
            </asp:TableRow>
            <asp:TableRow>
                <asp:TableCell HorizontalAlign="Left" ColumnSpan="4">
                    <asp:Label ID="lblMessage" runat="server" Width="444"></asp:Label>
                </asp:TableCell>
            </asp:TableRow>
        </asp:Table>        
    </div>
</asp:Content>
