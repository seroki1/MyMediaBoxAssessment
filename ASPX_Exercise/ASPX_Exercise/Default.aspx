<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeFile="Default.aspx.cs" Inherits="_Default" %>


<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
<script type="text/javascript">
    function getAjax() {
        var xhttp = new XMLHttpRequest();
        xhttp.onreadystatechange = function () {
            if (this.readyState == 4 && this.status == 200) {
                myTable(this);
            }
        };
        xhttp.open("GET", "https://test40-pa-dev01.uat.mymediabox.com/inbox/get-media-list-for-folder.xml?g4_ignoretransform=yes", true);
        xhttp.send();
    }
    function myTable(xml) {
        var i;
        var xmlDoc = xml.responseXML;
        var table = "<tr><th>MediaID</th><th>Short Description</th><th>Date Created</th><th>Title</th><th>FileSize</th></tr>";
        var x = xmlDoc.getElementsByTagName("get-media-list-for-folder");
        for (i = 0; i < x.length; i++) {
            table += "<tr><td>" +
                x[i].getElementsByTagName("MediaID")[0].childNodes[0].nodeValue +
                "</td><td>" +
                x[i].getElementsByTagName("ShortDescription")[0].childNodes[0].nodeValue +
                "</td><td>" +
                x[i].getElementsByTagName("DateCreated")[0].childNodes[0].nodeValue +
                "</td><td>" +
                x[i].getElementsByTagName("Title")[0].childNodes[0].nodeValue +
                "</td><td>" +
                x[i].getElementsByTagName("FileSize")[0].childNodes[0].nodeValue +
                "</td></tr>";
        }
        document.getElementById("demo").innerHTML = table;
    }

</script>



    <asp:GridView ID="GridView1" runat="server">
    </asp:GridView>

    <br />
    <br />
    <input type="button" onclick="getAjax()" title="Get AJAX" value="Get AJAX" />
    <br><br>
    <table id="demo"></table>

    </asp:Content>
