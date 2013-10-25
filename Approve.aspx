<%@ Page Title="" Language="VB" MasterPageFile="~/Site.master" AutoEventWireup="false"
    CodeFile="Approve.aspx.vb" Inherits="Approve" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="Server">
    <style type="text/css">
        .style3
        {
            width: 100%;
        }
        .style4
        {
            width: 100px;
        }
        .style5
        {
            width: 100px;
            height: 21px;
        }
        .style6
        {
            height: 21px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="Server">
    <asp:Label ID="lblReqTitle" runat="server" Font-Bold="True" Font-Size="X-Large">Change of Status Request</asp:Label>
    <br />
    <table class="style3">
        <tr>
            <td class="style5">
                <asp:Label ID="Label1" runat="server" Text="Name:" Font-Bold="True"></asp:Label>
            </td>
            <td class="style6">
                <asp:Label ID="lblName" runat="server"></asp:Label>
            </td>
        </tr>
        <tr>
            <td class="style4">
                <asp:Label ID="Label2" runat="server" Text="Request Date:" Font-Bold="True"></asp:Label>
            </td>
            <td>
                <asp:Label ID="lblReqDate" runat="server"></asp:Label>
            </td>
        </tr>
    </table>
    <br />
    <asp:Panel ID="panStatusChange" runat="server" Visible="False">
        <asp:Label ID="Label3" runat="server" Font-Size="Large" Text="Status Change - " Font-Bold="True"></asp:Label>
        <asp:Label ID="lblChange" runat="server" Font-Bold="True" Font-Size="Medium"></asp:Label>
        <br />
        <asp:Panel ID="panAddressPhone" runat="server" Visible="False">
            <asp:Panel ID="panAddress" runat="server" Visible="False">
                <table class="style3">
                    <tr>
                        <td class="style4">
                            <asp:Label ID="Label6" runat="server" Font-Bold="True" Text="Street:"></asp:Label>
                        </td>
                        <td>
                            <asp:Label ID="lblStreet" runat="server"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td class="style4">
                            <asp:Label ID="Label7" runat="server" Font-Bold="True" Text="City:"></asp:Label>
                        </td>
                        <td>
                            <asp:Label ID="lblCity" runat="server"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td class="style4">
                            <asp:Label ID="Label8" runat="server" Font-Bold="True" Text="Zip:"></asp:Label>
                        </td>
                        <td>
                            <asp:Label ID="lblZip" runat="server"></asp:Label>
                        </td>
                    </tr>
                </table>
            </asp:Panel>
            <asp:Panel ID="panPhone" runat="server" Visible="False">
                <table class="style3">
                    <tr>
                        <td class="style4">
                            <asp:Label ID="Label9" runat="server" Font-Bold="True" Text="Phone:"></asp:Label>
                        </td>
                        <td>
                            <asp:Label ID="lblPhone" runat="server"></asp:Label>
                        </td>
                    </tr>
                </table>
            </asp:Panel>
            <table class="style3">
                <tr>
                    <td class="style4">
                        <asp:Label ID="Label10" runat="server" Font-Bold="True" Text="Effective Date:"></asp:Label>
                    </td>
                    <td>
                        <asp:Label ID="lblEffectiveDate" runat="server"></asp:Label>
                    </td>
                </tr>
            </table>
        </asp:Panel>
        <asp:Panel ID="panFuneral" runat="server" Visible="False">
            <table class="style3">
                <tr>
                    <td class="style5">
                        <asp:Label ID="Label11" runat="server" Font-Bold="True" Text="Type:"></asp:Label>
                    </td>
                    <td class="style6">
                        <asp:Label ID="lblType" runat="server"></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td class="style4">
                        <asp:Label ID="Label12" runat="server" Font-Bold="True" Text="Relationship:"></asp:Label>
                    </td>
                    <td>
                        <asp:Label ID="lblRelationship" runat="server"></asp:Label>
                    </td>
                </tr>
            </table>
        </asp:Panel>
        <asp:Panel ID="panDatesDuration" runat="server" Visible="False">
            <table class="style3">
                <tr>
                    <td class="style4">
                        <asp:Label ID="Label13" runat="server" Font-Bold="True" Text="Start Date:"></asp:Label>
                    </td>
                    <td>
                        <asp:Label ID="lblStartDate" runat="server"></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td class="style4">
                        <asp:Label ID="Label14" runat="server" Font-Bold="True" Text="Return Date:"></asp:Label>
                    </td>
                    <td>
                        <asp:Label ID="lblReturnDate" runat="server"></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td class="style4">
                        <asp:Label ID="Label15" runat="server" Font-Bold="True" Text="Duration:"></asp:Label>
                    </td>
                    <td>
                        <asp:Label ID="lblDuration" runat="server"></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td class="style4">
                        <asp:Label ID="Label16" runat="server" Font-Bold="True" Text="Comments:"></asp:Label>
                    </td>
                    <td>
                        <asp:Label ID="lblComments" runat="server"></asp:Label>
                    </td>
                </tr>
            </table>
        </asp:Panel>
    </asp:Panel>
    <asp:Panel ID="panVacation" runat="server" Visible="False">
        <asp:Label ID="Label17" runat="server" Font-Size="Large" Text="Vacation" Font-Bold="True"></asp:Label>
        <br />
        <asp:PlaceHolder ID="phVacation" runat="server"></asp:PlaceHolder>
    </asp:Panel>
    <asp:Panel ID="panSick" runat="server" Visible="false">
        <asp:Label ID="Label4" runat="server" Font-Size="Large" Text="Sick" Font-Bold="true"></asp:Label>
        <br />
        <asp:PlaceHolder ID="phSick" runat="server"></asp:PlaceHolder>
    </asp:Panel>
    <br />
    <br />
    <asp:Panel ID="panApprove" runat="server" Visible="False">
    <asp:Label ID="Label5" runat="server" Text="Comments:"></asp:Label>
    <br />
    <asp:TextBox ID="tbComments" runat="server" Width="100%" Height="44px" Rows="2" TextMode="MultiLine"></asp:TextBox>
    <asp:Button ID="btnAccept" runat="server" Text="Accept" CausesValidation="False" />
    <asp:Button ID="btnDecline" runat="server" Text="Decline" 
            CausesValidation="False" />
    </asp:Panel>
</asp:Content>
