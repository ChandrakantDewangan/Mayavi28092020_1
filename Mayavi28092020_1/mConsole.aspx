<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPageReg.master" AutoEventWireup="true" CodeFile="mConsole.aspx.cs" Inherits="mConsole" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <script type="text/javascript">
        $(document).ready(function () {
            if (localStorage.getItem("url") !== "undefined" && localStorage.getItem("url") !== null) {
                var url = localStorage.getItem("url");
                $('#iframeAddDevice').attr("src", url);
                $(".deviceheight").height($(window).height() - 100);
            }
        });
    </script>
    <div class="container-fluid">
        <div class="panel" style="background-color: black;">
            <div class="panel-body">
                <iframe id="iframeAddDevice" class="deviceheight" style="border: none; width: 100%;"></iframe>
            </div>
        </div>
    </div>
</asp:Content>

