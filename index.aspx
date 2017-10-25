<%@ Page EnableEventValidation="false" Language="C#" Inherits="slcm.index" %>
<!DOCTYPE html>
<html>
<head runat="server">
	<title>Login</title>
    <link rel="stylesheet" href="css/login.css">
</head>
<body>
	

<div class="container">
  <div class="card"></div>
  <div class="card">
    <h1 class="title">Login</h1>
    <form runat="server" id="loginForm" method="post">
      <div class="input-container">
        <input type="text" id="username" runat="server" required="required"/>
        <label for="username">Username</label>
        <div class="bar"></div>
      </div>
      <div class="input-container">
        <input type="password" id="password" runat="server" required="required"/>
        <label for="password">Password</label>
        <div class="bar"></div>
      </div>
	  <label id="message" runat="server"></label>				
      <div class="button-container">
        <button type="submit" runat="server" onserverclick="CheckLogin"><span>Go</span></button>
      </div>
      <div class="footer"><a href="#">Forgot your password?</a></div>
    </form>
  </div>
  <div class="card alt">
    <div class="toggle"></div>
    <h1 class="title">Register
      <div class="close"></div>
    </h1>
    <form id="registerForm" method="post" action="register.aspx">
      <div class="input-container">
        <input name="username" type="text" id="usernameRegister" runat="server" required="required"/>
        <label for="usernameRegister">Username</label>
        <div class="bar"></div>
      </div>
      <div class="input-container">
        <input name="password" runat="server" type="password" id="passwordRegister" required="required"/>
        <label for="passwordRegister">Password</label>
        <div class="bar"></div>
      </div>

      <div class="button-container">
        <button type="submit" runat="server"><span>Next</span></button>
      </div>
    </form>
  </div>
</div>
</body>
<script
  src="https://code.jquery.com/jquery-3.2.1.min.js"
  integrity="sha256-hwg4gsxgFZhOsEEamdOYGBf13FyQuiTwlAQgxVSNgt4="
  crossorigin="anonymous"></script>
<script src="js/script.js"></script>
</html>
