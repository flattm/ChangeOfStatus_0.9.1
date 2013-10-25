<%@ Page Title="Home Page" Language="VB" MaintainScrollPositionOnPostback="true"
    MasterPageFile="~/Site.Master" AutoEventWireup="false" CodeFile="Default.aspx.vb"
    Inherits="_Default" %>

<asp:Content ID="HeaderContent" runat="server" ContentPlaceHolderID="HeadContent">
    <style type="text/css">
        .style1
        {
            width: 100%;
            vertical-align: top;
        }
        .style7
        {
            width: 114px;
        }
        .style10
        {
            width: 499px;
        }
        .style13
        {
            width: 95px;
        }
        
        .style17
        {
            width: 144px;
        }        
        .style26
        {
            width: 75px;
        }
        .style27
        {
            width: 80px;
        }
        .style28
        {
            width: 40px;
        }
        .style29
        {
            width: 67px;
        }
        .style33
        {
            width: 238px;
        }
        .style36
        {
            width: 498px;
        }
        .style37
        {
            width: 45px;
        }
        .style38
        {
            width: 100%;
        }
        .style39
        {
            width: 140px;
        }
        .style40
        {
            width: 49px;
        }
        .style41
        {
            width: 81px;
        }
        .style44
        {
            width: 124px;
        }
        .style45
        {
            width: 65px;
        }
        .style49
        {
            width: 160px;
        }
        .style50
        {
            width: 200px;
        }
        .style51
        {
            width: 90px;
            height: 26px;
        }
        .style52
        {
            width: 77px;
        }
        .style53
        {
            width: 85px;
        }
        .style54
        {
            width: 130px;
            height: 26px;
        }
        .style61
        {
            height: 26px;
        }
        .style63
        {
            width: 220px;
        }
        .style64
        {
            width: 225px;
        }
        .style65
        {
            width: 32px;
        }
        .style66
        {
            width: 70px;
        }
        .style67
        {
            width: 70px;
            height: 29px;
        }
        .style68
        {
            height: 29px;
        }
        .style69
        {
            width: 132px;
        }
    </style>
</asp:Content>
<asp:Content ID="BodyContent" runat="server" ContentPlaceHolderID="MainContent">
    <table class="style1">
        <tr>
            <td class="style40">
                Name:
            </td>
            <td>
                <asp:Label ID="lblName" runat="server"></asp:Label>
            </td>
        </tr>
        <tr>
            <td class="style40">
                Date:
            </td>
            <td>
                <asp:Label ID="lblDate" runat="server" Font-Size="Small" Font-Underline="True"></asp:Label>
                <asp:Calendar ID="cdrDate" runat="server" BackColor="White" BorderColor="White" BorderWidth="1px"
                    Enabled="False" Font-Names="Verdana" Font-Size="9pt" ForeColor="Black" Height="190px"
                    NextPrevFormat="ShortMonth" Visible="False" Width="350px">
                    <DayHeaderStyle Font-Bold="True" Font-Size="8pt" />
                    <NextPrevStyle Font-Bold="True" Font-Size="8pt" ForeColor="#333333" VerticalAlign="Bottom" />
                    <OtherMonthDayStyle ForeColor="#999999" />
                    <SelectedDayStyle BackColor="#630000" ForeColor="White" />
                    <TitleStyle BackColor="White" BorderColor="Black" BorderStyle="None" Font-Bold="True"
                        Font-Size="12pt" ForeColor="#630000" />
                    <TodayDayStyle BackColor="#CCCCCC" />
                </asp:Calendar>
            </td>
        </tr>
    </table>
    <br />
    <table class="style1">
        <tr>
            <td class="style69">
                Select all that apply:
            </td>
            <td class="style7">
                <asp:CheckBox ID="cbStatusChange" runat="server" Text="Status Change" AutoPostBack="True" />
            </td>
            <td class="style41">
                <asp:CheckBox ID="cbVacation" runat="server" Text="Vacation" AutoPostBack="True" />
            </td>
            <td>
                <asp:CheckBox ID="cbSick" runat="server" Text="Sick" AutoPostBack="True" />
            </td>
        </tr>
    </table>
    <asp:Panel ID="panStatus" runat="server" Enabled="False" Visible="False" BorderStyle="Groove"
        BorderWidth="5px" BorderColor="#630000">
        <h2>
            Status Change:</h2>
        <h3>
            Select a status change from the dropdown list and enter any aditional 
            information needed.</h3>
        <br />
        <table class="style8">
            <tr>
                <td class="style33" valign="top">
                    <table class="style1">
                        <tr>
                            <td class="style37">
                                Select:
                            </td>
                            <td class="style10">
                                <asp:DropDownList ID="ddlStatusChange" runat="server" AutoPostBack="True">
                                    <asp:ListItem></asp:ListItem>
                                    <asp:ListItem>Change of Address/Phone</asp:ListItem>
                                    <asp:ListItem>Jury Duty</asp:ListItem>
                                    <asp:ListItem>Funeral</asp:ListItem>
                                    <asp:ListItem>Leave of Absence</asp:ListItem>
                                    <asp:ListItem>FMLA</asp:ListItem>
                                    <asp:ListItem>Medical Leave</asp:ListItem>
                                </asp:DropDownList>
                                <asp:RequiredFieldValidator ID="rfvStatusChange" runat="server" 
                                    ControlToValidate="ddlStatusChange" Display="None" 
                                    ErrorMessage="Select a Status Change." ValidationGroup="default"></asp:RequiredFieldValidator>
                            </td>
                        </tr>
                    </table>
                </td>
                <td class="style36" valign="top">
                    <asp:Panel ID="panJury" runat="server" Enabled="False" Visible="False">
                        *Court documentation is required<br />
                    </asp:Panel>
                    <asp:Panel ID="panFuneral" runat="server" Enabled="False" Visible="False">
                        <table class="style8">
                            <tr>
                                <td class="style13" valign="top">
                                    <asp:DropDownList ID="ddlFuneral" runat="server" AutoPostBack="True">
                                        <asp:ListItem>Select...</asp:ListItem>
                                        <asp:ListItem>Immediate Family</asp:ListItem>
                                        <asp:ListItem>Extended Family</asp:ListItem>
                                    </asp:DropDownList>
                                </td>
                                <td valign="top">
                                    <asp:DropDownList ID="ddlImmed" runat="server" Enabled="False" Visible="False">
                                        <asp:ListItem>Select...</asp:ListItem>
                                        <asp:ListItem>Spouse</asp:ListItem>
                                        <asp:ListItem>Parent</asp:ListItem>
                                        <asp:ListItem>[Step] Child</asp:ListItem>
                                        <asp:ListItem>Sibling</asp:ListItem>
                                    </asp:DropDownList>
                                    <asp:DropDownList ID="ddlOther" runat="server" Enabled="False" Visible="False">
                                        <asp:ListItem>Select...</asp:ListItem>
                                        <asp:ListItem>Parent of Spouse</asp:ListItem>
                                        <asp:ListItem>Stepbrother</asp:ListItem>
                                        <asp:ListItem>Stepsister</asp:ListItem>
                                        <asp:ListItem>Grandparent</asp:ListItem>
                                        <asp:ListItem>Grandchild</asp:ListItem>
                                        <asp:ListItem>Brother/Sister-in-law</asp:ListItem>
                                        <asp:ListItem>Son/Daughter-in-law</asp:ListItem>
                                        <asp:ListItem>Step-partent</asp:ListItem>
                                    </asp:DropDownList>
                                </td>
                                <td valign="top">
                                    <asp:Label ID="lblImmed" runat="server" Enabled="False" Text="*5 Days Allowed" Visible="False"></asp:Label>
                                    <asp:Label ID="lblOther" runat="server" Enabled="False" Text="*3 Days Allowed" Visible="False"></asp:Label>
                                </td>
                            </tr>
                        </table>
                        <asp:RequiredFieldValidator ID="rfvFuneral" runat="server" ControlToValidate="ddlFuneral"
                            Display="None" ErrorMessage="Select relationship to you." InitialValue="Select..."
                            ValidationGroup="default"></asp:RequiredFieldValidator>
                        <asp:RequiredFieldValidator ID="rfvImmed" runat="server" ControlToValidate="ddlImmed"
                            Display="None" ErrorMessage="Specify relationship to you." InitialValue="Select..."
                            ValidationGroup="default"></asp:RequiredFieldValidator>
                        <asp:RequiredFieldValidator ID="rfvOther" runat="server" ControlToValidate="ddlOther"
                            Display="None" ErrorMessage="Specify relationship to you." InitialValue="Select..."
                            ValidationGroup="default"></asp:RequiredFieldValidator>
                        <br />
                    </asp:Panel>
                </td>
            </tr>
        </table>
        <table class="style8">
            <tr>
                <td class="style20">
                    <table class="style8">
                        <tr>
                            <td class="style17">
                                Change is Effective on:
                            </td>
                            <td class="style44">
                                <asp:Label ID="lblChangeFrom" runat="server" Font-Underline="True"></asp:Label>
                                <asp:ImageButton ID="ibChangeFrom" runat="server" CausesValidation="False" Height="18px"
                                    ImageAlign="AbsBottom" ImageUrl="~/Images/calendar_icon1.png" PostBackUrl="~/Default.aspx" />
                                <asp:Calendar ID="cdrChangeFrom" runat="server" BackColor="White" BorderColor="White"
                                    BorderWidth="1px" Enabled="False" Font-Names="Verdana" Font-Size="9pt" ForeColor="Black"
                                    Height="190px" NextPrevFormat="ShortMonth" Visible="False" Width="350px">
                                    <DayHeaderStyle Font-Bold="True" Font-Size="8pt" />
                                    <NextPrevStyle Font-Bold="True" Font-Size="8pt" ForeColor="#333333" VerticalAlign="Bottom" />
                                    <OtherMonthDayStyle ForeColor="#999999" />
                                    <SelectedDayStyle BackColor="#630000" ForeColor="White" />
                                    <TitleStyle BackColor="White" BorderColor="Black" BorderStyle="None" Font-Bold="True"
                                        Font-Size="12pt" ForeColor="#630000" />
                                    <TodayDayStyle BackColor="#CCCCCC" />
                                </asp:Calendar>
                            </td>
                            <td class="style52">
                                &nbsp;<asp:Label ID="lblReturning" runat="server" Text="Returning:"></asp:Label>
                            </td>
                            <td>
                                <asp:Label ID="lblChangeReturn" runat="server" Font-Underline="True"></asp:Label>
                                <asp:ImageButton ID="ibChangeReturn" runat="server" CausesValidation="False" Height="18px"
                                    ImageAlign="AbsBottom" ImageUrl="~/Images/calendar_icon1.png" PostBackUrl="~/Default.aspx"
                                    Visible="False" />
                                <asp:Calendar ID="cdrChangeReturn" runat="server" BackColor="White" BorderColor="White"
                                    BorderWidth="1px" Enabled="False" Font-Names="Verdana" Font-Size="9pt" ForeColor="Black"
                                    Height="190px" NextPrevFormat="ShortMonth" Visible="False" Width="350px">
                                    <DayHeaderStyle Font-Bold="True" Font-Size="8pt" />
                                    <NextPrevStyle Font-Bold="True" Font-Size="8pt" ForeColor="#333333" VerticalAlign="Bottom" />
                                    <OtherMonthDayStyle ForeColor="#999999" />
                                    <SelectedDayStyle BackColor="#630000" ForeColor="White" />
                                    <TitleStyle BackColor="White" BorderColor="Black" BorderStyle="None" Font-Bold="True"
                                        Font-Size="12pt" ForeColor="#630000" />
                                    <TodayDayStyle BackColor="#CCCCCC" />
                                </asp:Calendar>
                            </td>
                        </tr>
                    </table>
                </td>
            </tr>
        </table>
        <asp:Panel ID="panComments" runat="server">
            <table class="style38">
                <tr>
                    <td class="style54">
                        <asp:Label ID="lblDurationOfAbsence" runat="server" Text="Duration of Absence:"></asp:Label>
                    </td>
                    <td class="style51">
                        <asp:TextBox ID="tbDouration" runat="server" Width="80px" ReadOnly="True" 
                            Enabled="False"></asp:TextBox>
                    </td>
                    <td class="style61">
                        <asp:Label ID="lblDays" runat="server" Text="Day(s)"></asp:Label>
                        <asp:RequiredFieldValidator ID="rfvDuration" runat="server" ControlToValidate="tbDouration"
                            Display="None" ErrorMessage="Please ensure Reason for Change and Start and Return Dates are selected. "
                            ValidationGroup="default"></asp:RequiredFieldValidator>
                    </td>
                </tr>
            </table>
            <table class="style38">
                <tr>
                    <td class="style50">
                        <asp:Label ID="lblComments" runat="server" Text="Other Information or Comments:"></asp:Label>
                    </td>
                    <td>
                        <asp:TextBox ID="tbComments" runat="server" TextMode="MultiLine" 
                            onkeyup="return ismaxlength(this,200)" Width="500px" MaxLength="200" Rows="3"></asp:TextBox>
                        <br />
                        200 Character Max.</td>
                </tr>
            </table>
        </asp:Panel>
    <asp:Panel ID="panAddress" runat="server" Visible="false" Enabled="false">
        <asp:RadioButtonList ID="rblAddressPhone" runat="server" AutoPostBack="True" 
            RepeatDirection="Horizontal">
            <asp:ListItem>Address</asp:ListItem>
            <asp:ListItem>Phone</asp:ListItem>
            <asp:ListItem Selected="True">Both</asp:ListItem>
        </asp:RadioButtonList>
        <table class="style38">
            <tr>
                <td class="style66">
                    Address:
                </td>
                <td class="style40">
                    Street:
                </td>
                <td class="style63">
                    <asp:TextBox ID="tbStreet" runat="server" Width="200px" MaxLength="50"></asp:TextBox>
                </td>
                <td class="style65">
                    City:
                </td>
                <td class="style64">
                    <asp:TextBox ID="tbCity" runat="server" Width="200px" MaxLength="50"></asp:TextBox>
                </td>
                <td>
                    Zip:
                </td>
                <td>
                    <asp:TextBox ID="tbZip" runat="server" Width="80px" MaxLength="5"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td class="style67">
                    Phone:
                </td>
                <td colspan="6" class="style68">
                    <asp:TextBox ID="tbPhone" runat="server" Width="140px"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="rfvStreet" runat="server" 
                        ControlToValidate="tbstreet" Display="None" ErrorMessage="Enter the street." 
                        ValidationGroup="default"></asp:RequiredFieldValidator>
                    <asp:RequiredFieldValidator ID="rfvCity" runat="server" 
                        ControlToValidate="tbcity" Display="None" ErrorMessage="Enter the city." 
                        ValidationGroup="default"></asp:RequiredFieldValidator>
                    <asp:RequiredFieldValidator ID="rfvZip" runat="server" 
                        ControlToValidate="tbzip" Display="None" ErrorMessage="Enter the zip." 
                        ValidationGroup="default"></asp:RequiredFieldValidator>
                    <asp:RequiredFieldValidator ID="rfvPhone" runat="server" 
                        ControlToValidate="tbPhone" Display="None" 
                        ErrorMessage="Enter phone number." ValidationGroup="default"></asp:RequiredFieldValidator>
                    <asp:RegularExpressionValidator ID="revZip" runat="server" 
                        ControlToValidate="tbZip" Display="None" 
                        ErrorMessage="Zip must be numbers only." ValidationExpression="\d{5}" 
                        ValidationGroup="default"></asp:RegularExpressionValidator>
                    <asp:RegularExpressionValidator ID="revPhone" runat="server" 
                        ControlToValidate="tbPhone" Display="None" 
                        ErrorMessage="Please format phone number correctly." 
                        ValidationExpression="^\D?(\d{3})\D?\D?(\d{3})\D?(\d{4})$" 
                        ValidationGroup="default"></asp:RegularExpressionValidator>
                </td>
            </tr>
        </table>
    </asp:Panel>
    </asp:Panel>
    <br />
    <asp:Panel ID="panVacation" runat="server" Enabled="False" Visible="False" BorderColor="#630000"
        BorderStyle="Groove" BorderWidth="5px">
        <h2>
            Vacation:</h2>
        <div>
            <asp:RadioButtonList ID="rblVaca" runat="server" AutoPostBack="True" RepeatDirection="Horizontal">
                <asp:ListItem>Add New Vacation</asp:ListItem>
                <asp:ListItem>Cancel Existing Vacation</asp:ListItem>
            </asp:RadioButtonList>
            <br />
        </div>
        <asp:Panel ID="panTotalHrError" runat="server" Enabled="false" Visible="false">
            <h4>
                Total hours must be a multiple of 8.</h4>
        </asp:Panel>
        <asp:Panel ID="panEnterInfoError" runat="server" Enabled="false" Visible="false">
            <h4>
                Please ensure all other information is entered before selecting a date.</h4>
        </asp:Panel>
        <asp:Panel ID="panAddVaca" runat="server" Enabled="false" Visible="false">
                <div>
                    Select whether the vacation will be a half day or full day(s). If it is a half 
                    day select AM or PM when prompted. If the vacation will be more than one day, 
                    use the calendar buttons to select the date range. The total hours will be 
                    calcualted automatically.</div>
                    <br />
            <table class="style8">
                <tr>
                    <td rowspan="2" valign="top" class="style53">
                        <asp:RadioButtonList ID="rblFullHalf" runat="server" Height="100%" AutoPostBack="True">
                            <asp:ListItem>Full Day(s)</asp:ListItem>
                            <asp:ListItem>Half Day</asp:ListItem>
                        </asp:RadioButtonList>
                    </td>
                    <td class="style26" style="padding-top: 5px; vertical-align: top;">
                        Total Hours:
                    </td>
                    <td style="padding-top: 5px; vertical-align: top;" class="style45">
                        <asp:TextBox runat="server" Width="60px" ID="tbTime" ReadOnly="True" 
                            Enabled="False"></asp:TextBox>
                    </td>
                    <td style="padding-top: 5px; vertical-align: top;" class="style28">
                        From:
                    </td>
                    <td style="padding-top: 5px; vertical-align: top;" width="100px">
                        <asp:Label ID="lblFrom" runat="server" Font-Underline="True"></asp:Label>
                        <asp:ImageButton ID="ibFrom" runat="server" CausesValidation="False" Height="18px"
                            ImageAlign="AbsBottom" ImageUrl="~/Images/calendar_icon1.png" PostBackUrl="~/Default.aspx" />
                        <asp:Calendar ID="cdrFrom" runat="server" BackColor="White" BorderColor="White" BorderWidth="1px"
                            Enabled="False" Font-Names="Verdana" Font-Size="9pt" ForeColor="Black" Height="190px"
                            NextPrevFormat="ShortMonth" Visible="False" Width="350px" 
                            EnableTheming="True">
                            <DayHeaderStyle Font-Bold="True" Font-Size="8pt" />
                            <NextPrevStyle Font-Bold="True" Font-Size="8pt" ForeColor="#333333" VerticalAlign="Bottom" />
                            <OtherMonthDayStyle ForeColor="#999999" />
                            <SelectedDayStyle BackColor="#630000" ForeColor="White" />
                            <TitleStyle BackColor="White" BorderColor="Black" BorderStyle="None" Font-Bold="True"
                                Font-Size="12pt" ForeColor="#630000" />
                            <TodayDayStyle BackColor="#CCCCCC" />
                        </asp:Calendar>
                    </td>
                    <td style="padding-top: 5px; vertical-align: top;" class="style29">
                        Returning:
                    </td>
                    <td style="padding-top: 5px; vertical-align: top;" width="100px">
                        <asp:Label ID="lblReturn" runat="server" Font-Underline="True"></asp:Label>
                        <asp:ImageButton ID="ibReturn" runat="server" CausesValidation="False" Height="18px"
                            ImageAlign="AbsBottom" ImageUrl="~/Images/calendar_icon1.png" PostBackUrl="~/Default.aspx"
                            Enabled="False" Visible="False" />
                        <asp:Calendar ID="cdrReturn" runat="server" BackColor="White" BorderColor="White"
                            BorderWidth="1px" Enabled="False" Font-Names="Verdana" Font-Size="9pt" ForeColor="Black"
                            Height="190px" NextPrevFormat="ShortMonth" Visible="False" Width="350px">
                            <DayHeaderStyle Font-Bold="True" Font-Size="8pt" />
                            <NextPrevStyle Font-Bold="True" Font-Size="8pt" ForeColor="#333333" VerticalAlign="Bottom" />
                            <OtherMonthDayStyle ForeColor="#999999" />
                            <SelectedDayStyle BackColor="#630000" ForeColor="White" />
                            <TitleStyle BackColor="White" BorderColor="Black" BorderStyle="None" Font-Bold="True"
                                Font-Size="12pt" ForeColor="#630000" />
                            <TodayDayStyle BackColor="#CCCCCC" />
                        </asp:Calendar>
                    </td>
                </tr>
                <tr>
                    <td colspan="6">
                        <asp:RadioButtonList ID="rblAMPM" runat="server" Enabled="False" RepeatDirection="Horizontal"
                            Visible="False" AutoPostBack="True">
                            <asp:ListItem>AM</asp:ListItem>
                            <asp:ListItem>PM</asp:ListItem>
                        </asp:RadioButtonList>
                    </td>
                </tr>
            </table>
        </asp:Panel>
        <br />
        <asp:Panel ID="panCancelVaca" runat="server" Enabled="false" Visible="false">
            <table class="style38">
                <tr>
                    <td class="style47">
                        Select the vacation date range which you would like to cancel: 
                    </td>
                </tr>
                <tr>
                    <td class="style47">
                        &nbsp;</td>
                </tr>
                <tr>
                    <td>
                        Start Date:&nbsp;
                        <asp:Label ID="lblCancelStart" runat="server" Font-Underline="True"></asp:Label>
                        <asp:ImageButton ID="ibCancelStart" runat="server" CausesValidation="False" Height="18px"
                            ImageAlign="AbsBottom" ImageUrl="~/Images/calendar_icon1.png" PostBackUrl="~/Default.aspx" />
                        <asp:Calendar ID="cdrCancelStart" runat="server" BackColor="White" BorderColor="White"
                            BorderWidth="1px" Enabled="False" Font-Names="Verdana" Font-Size="9pt" ForeColor="Black"
                            Height="190px" NextPrevFormat="ShortMonth" Visible="False" Width="350px">
                            <DayHeaderStyle Font-Bold="True" Font-Size="8pt" />
                            <NextPrevStyle Font-Bold="True" Font-Size="8pt" ForeColor="#333333" VerticalAlign="Bottom" />
                            <OtherMonthDayStyle ForeColor="#999999" />
                            <SelectedDayStyle BackColor="#630000" ForeColor="White" />
                            <TitleStyle BackColor="White" BorderColor="Black" BorderStyle="None" Font-Bold="True"
                                Font-Size="12pt" ForeColor="#630000" />
                            <TodayDayStyle BackColor="#CCCCCC" />
                        </asp:Calendar>
                    </td>
                </tr>
                <tr>
                    <td>
                        Return Date:
                        <asp:Label ID="lblCancelEnd" runat="server" Font-Underline="True"></asp:Label>
                        <asp:ImageButton ID="ibCancelEnd" runat="server" CausesValidation="False" 
                            Height="18px" ImageAlign="AbsBottom" ImageUrl="~/Images/calendar_icon1.png" 
                            PostBackUrl="~/Default.aspx" />
                        <asp:Calendar ID="cdrCancelEnd" runat="server" BackColor="White" 
                            BorderColor="White" BorderWidth="1px" Enabled="False" Font-Names="Verdana" 
                            Font-Size="9pt" ForeColor="Black" Height="190px" NextPrevFormat="ShortMonth" 
                            Visible="False" Width="350px">
                            <DayHeaderStyle Font-Bold="True" Font-Size="8pt" />
                            <NextPrevStyle Font-Bold="True" Font-Size="8pt" ForeColor="#333333" 
                                VerticalAlign="Bottom" />
                            <OtherMonthDayStyle ForeColor="#999999" />
                            <SelectedDayStyle BackColor="#630000" ForeColor="White" />
                            <TitleStyle BackColor="White" BorderColor="Black" BorderStyle="None" 
                                Font-Bold="True" Font-Size="12pt" ForeColor="#630000" />
                            <TodayDayStyle BackColor="#CCCCCC" />
                        </asp:Calendar>
                    </td>
                </tr>
            </table>
        </asp:Panel>
        <div>
            <asp:Label ID="lblSelectDateFirst" runat="server" Font-Bold="True" 
                ForeColor="Red" Text="Please select a date before adding the vacation." 
                Visible="False"></asp:Label>
            <br />
            <asp:Label ID="lblSelectEnd" runat="server" Font-Bold="True" ForeColor="Red" 
                Text="Please select a return date before adding the vacation." Visible="False"></asp:Label>
            <br />
            <asp:Button ID="btnAddVaca" runat="server" Text="Add" Width="70px" ValidationGroup="vaca" />
            <asp:Button ID="btnRemoveVaca" runat="server" Text="Remove" Width="70px" CausesValidation="False" />
        </div>
        <asp:ListBox ID="lbVaca" runat="server" Width="100%"></asp:ListBox>
    </asp:Panel>
    <br />
    <asp:Panel ID="panSick" runat="server" Enabled="False" Visible="False" BorderColor="#630000"
        BorderStyle="Groove" BorderWidth="5px">
        <h2>
            Sick:</h2>
        <table class="style38">
            <tr>
                <td class="style49" valign="top">
                    Date:&nbsp;
                    <asp:Label ID="lblSickDate" runat="server" Font-Underline="True"></asp:Label>
                    <asp:ImageButton ID="ibSickDate" runat="server" CausesValidation="False" Height="18px"
                        ImageAlign="AbsBottom" ImageUrl="~/Images/calendar_icon1.png" PostBackUrl="~/Default.aspx" />
                    <asp:Calendar ID="cdrSickDate" runat="server" BackColor="White" BorderColor="White"
                        BorderWidth="1px" Enabled="False" Font-Names="Verdana" Font-Size="9pt" ForeColor="Black"
                        Height="190px" NextPrevFormat="ShortMonth" Visible="False" Width="350px">
                        <DayHeaderStyle Font-Bold="True" Font-Size="8pt" />
                        <NextPrevStyle Font-Bold="True" Font-Size="8pt" ForeColor="#333333" VerticalAlign="Bottom" />
                        <OtherMonthDayStyle ForeColor="#999999" />
                        <SelectedDayStyle BackColor="#630000" ForeColor="White" />
                        <TitleStyle BackColor="White" BorderColor="Black" BorderStyle="None" Font-Bold="True"
                            Font-Size="12pt" ForeColor="#630000" />
                        <TodayDayStyle BackColor="#CCCCCC" />
                    </asp:Calendar>
                </td>
                <td class="style27" valign="top">
                    &nbsp; Total time:
                </td>
                <td class="style13" valign="top">
                    &nbsp; Hours:
                    <asp:DropDownList ID="ddlHours" runat="server">
                        <asp:ListItem>0</asp:ListItem>
                        <asp:ListItem>1</asp:ListItem>
                        <asp:ListItem>2</asp:ListItem>
                        <asp:ListItem>3</asp:ListItem>
                        <asp:ListItem>4</asp:ListItem>
                        <asp:ListItem>5</asp:ListItem>
                        <asp:ListItem>6</asp:ListItem>
                        <asp:ListItem>7</asp:ListItem>
                        <asp:ListItem>8</asp:ListItem>
                    </asp:DropDownList>
                </td>
                <td valign="top">
                    &nbsp; Minutes:
                    <asp:DropDownList ID="ddlMins" runat="server">
                        <asp:ListItem>0</asp:ListItem>
                        <asp:ListItem>15</asp:ListItem>
                        <asp:ListItem>30</asp:ListItem>
                        <asp:ListItem>45</asp:ListItem>
                    </asp:DropDownList>
                </td>
            </tr>
        </table>
        <div>
            <asp:Button ID="btnSickAdd" runat="server" Text="Add" Width="70px" CausesValidation="False" />
            <asp:Button ID="btnSickRemove" runat="server" Text="Remove" Width="70px" CausesValidation="False" />
        </div>
        <asp:ListBox ID="lbSick" runat="server" Width="100%"></asp:ListBox>
    </asp:Panel>
    <br />
    <table class="style38">
        <tr>
            <td class="style39">
                Authorizing Manager:
                  <asp:DropDownList ID="ddlManager" runat="server" DataSourceID="dsEmployeeList" DataTextField="FullName"
                    DataValueField="FullName">
                </asp:DropDownList>
                <asp:SqlDataSource ID="dsEmployeeList" runat="server" ConnectionString="<%$ ConnectionStrings:[...]ConnectionString %>"
                    SelectCommand="SELECT DISTINCT [FullName] FROM [vwUMUser] WHERE ([IsActive] = @IsActive) ORDER BY [FullName]"
                    ProviderName="System.Data.SqlClient">
                    <SelectParameters>
                        <asp:Parameter DefaultValue="True" Name="IsActive" Type="Boolean" />
                    </SelectParameters>
                </asp:SqlDataSource>
            </td>
        </tr>
    </table>
    <asp:RequiredFieldValidator ID="rfvManager" runat="server" ControlToValidate="ddlManager"
        Display="None" ErrorMessage="Select an Authorizing Manager first." ValidationGroup="default"></asp:RequiredFieldValidator>
    <br />
    <asp:ValidationSummary ID="valSum" runat="server" ValidationGroup="default" DisplayMode="List"
        Font-Bold="True" ForeColor="Red" />
    <asp:Panel ID="panSelectOne" runat="server" Enabled="False" Font-Bold="True" 
        ForeColor="Red" Visible="False">
        Select atleast one 'Change of Status' first.</asp:Panel>
            <asp:Panel ID="panVacaVal" runat="server" Enabled="False" Font-Bold="True" 
        ForeColor="Red" Visible="False">
        Add at least one vacation.</asp:Panel>
            <asp:Panel ID="panSickVal" runat="server" Enabled="False" Font-Bold="True" 
        ForeColor="Red" Visible="False">
        Add at least one sick day.</asp:Panel>
        <br />
    <asp:Button ID="btnSubmit" runat="server" Text="Submit" ValidationGroup="default" />
</asp:Content>
