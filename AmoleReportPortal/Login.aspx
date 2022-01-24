<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="AmoleReportPortal.Login" %>

<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Amole Portal</title>
    <script type="text/javascript" src="https://ajax.googleapis.com/ajax/libs/jquery/1.8.3/jquery.min.js"></script>
    <meta charset="utf-8" />
    <meta name="viewpoint" content="width=device-width, intial-scale=1.0" />
    <link rel="stylesheet" href="Css/style.css" />
    <link rel="icon" href="image/AmoleIcon.jpg" type="image/x-icon" />
    <meta name="viewport" content="width=device-width, initial-scale=1.0" />
    <script type="text/javascript" src="Scripts/jquery-1.8.2.min.js">
    </script>
    <%--    <script>
            $().ready(function () {
                if (document.referrer != 'http://localhost:26924/') {
                history.pushState(null, null, 'Login');
                window.addEventListener('popstate', function () {
                    history.pushState(null,<a href="Login.aspx">Login.aspx</a> null, 'Login');
                });
            }
        });
   </script>--%>
    <script type="text/javascript">

        $(document).ready(function () {

            window.history.pushState(null, "", window.location.href);

            window.onpopstate = function () {

                window.history.pushState(null, "", window.location.href);

            };

        });

    </script>
</head>
<body>
    <form runat="server">
        <div class="container">
            <div class="box1">
                <div class="login_input">
                    <h1>Welcome Back ;)</h1>
                    <p>
                        Please login with your personal information by your user id and password so we can keep you connected
                    to
                    the<b> Amole Portal</b>.
                    </p>
                        <section>
                            <!--                    <img src="images/User_ID.png">-->
                            <span>
                                <!--                        <label for="User Id">User Id</label>-->
                                <input type="text" placeholder="User ID" name="LoginID" autocomplete="off" id="LoginID" runat="server" readonly 
    onfocus="this.removeAttribute('readonly');"/>
                            </span>
                            <!--                    <img class="Confirmation" src="images/Confirm.png">-->

                        </section>
                        <section>
                            <span>
                                <!--                        <label for="Pass">Password</label>-->
                                <input type="password" placeholder="Password" name="password" id="password" runat="server" readonly 
    onfocus="this.removeAttribute('readonly');"/>
                            </span>
                        </section>
                    <asp:GridView ID="GridView1" runat="server"></asp:GridView>
                    <asp:Label ID="Label1" runat="server" Text="" CssClass="label1"></asp:Label>
                    <asp:GridView ID="GridView2" runat="server" GridLines="None" CssClass="gridview2"></asp:GridView>
                    <div class="links">
                        <label for="Login" class="Button">Login</label><span style="font-size:12pt"><asp:LinkButton ID="LinkButton1" runat="server" OnClick="LinkButton1_Click">Reset Password</asp:LinkButton></span>
                        <input type="submit" name="Login" id="Login">
                        <!-- <%--<a href="#">Forgot Password?</a>--%> -->
                    </div>
                </div>
                <div class="join_us">
                    <h2>Join Us</h2>
                    <span>
                        <a href="https://www.facebook.com/MyAmoleOfficial/">
                            <img src="image/facebook.png" title="@myamole">
                            </a>
                    </span>
                    <span>
                        <a href="https://twitter.com/myamole">
                            <img src="image/Twitter.png" title="@myamole">
                            </a>
                    </span>
                    <span>
                        <a href="https://www.instagram.com/myamole/">
                            <img src="image/Instagram.png" title="@myamole">
                            </a>
                    </span>
                    <span>
                        <a href="https://t.me/AmoleChatBot">
                            <img src="image/telegram2.png" title="@AmoleChatBot">
                            </a>
                    </span>

                </div>
            </div>
            <div class="box2">
                <div class="amole">
                    <div class="logo">
                        <img src="image/Amole-Logo.png" alt="">
                    </div>
                    <!-- <div class="line">

                </div> -->
                    <div class="contact_us">
                        <h2>Contact Us</h2>
                        <div class="call">
                            <img src="image/Phone6.jpg">
                            <h1>6294 </h1>
                            <p>
                                Call our call center to speak with a customer service agent.
                            </p>
                        </div>
                        <div class="sms">
                            <img src="image/Message4.jpg">
                            <h1>8833</h1>
                            <p>Text CALL ME to 8833 and a customer service agent will call you as soon as possible.</p>
                        </div>
                        <div class="help_desk" style="width: 100%">
                            &nbsp;<a href="helpDeskc.aspx" style="text-decoration: none">Technical Support Help Desk</a>
                        </div>
                    </div>
                </div>
                <div class="ad">
                    <img src="image/cashback.jpg">

                    <h3>5% CASHBACK INSTANT WHEN YOU PAY WITH AMOLE!</h3>
                    <p>
                        Buy groceries at Shoa, Abadir and Queen supermarkets and <u>get 5% cash back</u>.
                    </p>
                    <p>
                        Pay your check and <u>get 5% cash back</u> at Pizza Hut, Savour, Mamas Kitchen, Five Loaves, Lime
                    Tree, Villa Verde, Hadero (Jupiter Hotel), MK's Bar & Restaurant and Babis Bistro and more locations
                    coming.
                    </p>
                    <p>
                        Order online through Z-Mall and others and <u>get 5% cash back</u>.
                    </p>

                </div>

            </div>
        </div>
    </form>
</body>
</html>
