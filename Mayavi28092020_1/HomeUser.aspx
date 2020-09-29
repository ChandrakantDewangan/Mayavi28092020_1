<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPageReg.master" AutoEventWireup="true" CodeFile="HomeUser.aspx.cs" Inherits="HomeUser" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div ng-app="myApp" ng-controller="myCtrl">
        <asp:HiddenField ID="HF_UID" runat="server" />
        <span style="display: none;">{{ UID }}</span>
        <span style="display: none;">{{ DID }}</span>
        <br />
        <br />
        <br />
        <br />
        <br />
        <br />
        <div class="container">
            <table width="100%">
                <tr>
                    <td>
                        <h1>Devices</h1>
                    </td>
                    <td class="text-right">
                        <button type="button" class="btn btn-warning" data-toggle="modal" data-target="#AddDevice">
                            Add Device
                        </button>
                    </td>
                </tr>
            </table>
            <div class="modal fade" id="AddDevice">
                <div class="modal-dialog">
                    <div class="modal-content">
                        <div class="modal-header">
                            <table width="100%">
                                <tr>
                                    <td>
                                        <h4 class="modal-title">Add Device</h4>
                                    </td>
                                    <td>
                                        <button type="button" class="close" data-dismiss="modal">&times;</button>
                                    </td>
                                </tr>
                            </table>
                        </div>
                        <div class="modal-body">
                            <div class="form-group">
                                <label>DEVICE NAME:</label>
                                <input type="text" ng-model="DEVICE_NAME" class="form-control" />
                            </div>
                        </div>
                        <div class="modal-footer">
                            <button type="button" class="btn btn-danger" data-dismiss="modal" ng-click="btnInsert_Click()">Add</button>
                        </div>
                    </div>
                </div>
            </div>
            <div class="modal fade" id="UpdateDevice">
                <div class="modal-dialog">
                    <div class="modal-content">
                        <div class="modal-header">
                            <table width="100%">
                                <tr>
                                    <td>
                                        <h4 class="modal-title">Update Device {{ DID }}</h4>
                                    </td>
                                    <td>
                                        <button type="button" class="close" data-dismiss="modal">&times;</button>
                                    </td>
                                </tr>
                            </table>
                        </div>
                        <div class="modal-body">
                            <div class="form-group">
                                <label>DEVICE NAME:</label>
                                <input type="text" ng-model="DEVICE_NAME" class="form-control" />
                            </div>
                        </div>
                        <div class="modal-footer">
                            <button type="button" class="btn btn-danger" data-dismiss="modal" ng-click="btnUpdate_Click()">Update</button>
                        </div>
                    </div>
                </div>
            </div>
            <ul class="list-group">
                <li class="list-group-item d-flex justify-content-between align-items-center"
                    ng-repeat="DEVICES in DEVICES_C">
                    <table width="100%">
                        <tr>
                            <td>
                                <h3 ng-click="Select_DEVICES_ByDID('?arg='+DEVICES.USER_NAME+'&arg='+DEVICES.DEVICE_ID)" class="mb-1 text-info">{{ DEVICES.DEVICE_NAME }}
                                    <img src="assets/images/external-link.png" width="16" />
                                </h3>
                                <b>Device ID :</b> {{ DEVICES.DEVICE_ID }} ,
                                <b>Key :</b> {{ DEVICES.DEVICE_KYE }}
                            </td>
                            <td class="text-right"><span class="badge badge-primary badge-pill">{{ DEVICES.TXRX_LIMIT }}</span></td>
                        </tr>
                    </table>
                    <table width="100%">
                        <tr>
                            <td>
                                <small>{{ DEVICES.CONNECTION_STATUS }}</small>
                            </td>
                            <td class="text-right">
                                <img src="assets/images/pencil.png" data-toggle="modal"
                                    data-target="#UpdateDevice" ng-click="UPDATE_DEVICES_BY_DID(DEVICES.DID)" />
                                <img src="assets/images/delete.png" ng-click="DELETE_DEVICES_BY_DID(DEVICES.DID)" />
                            </td>
                        </tr>
                    </table>
                </li>
            </ul>
        </div>
        <br />
        <br />
        <br />
        <br />
        <br />
        <br />
        <br />
        <br />
        <br />
        <br />
        <br />
        <br />
    </div>
    <script>
        var app = angular.module('myApp', []);
        app.controller('myCtrl', function ($scope, $http, $window) {
            $scope.UID = document.getElementById('<%= HF_UID.ClientID %>').value;
            LoadData();
            function LoadData() {
                $http.get("UserDetails_ws.asmx/GetDevicesByUserID?UserID=" + $scope.UID).then(function (response) {
                    $scope.DEVICES_C = response.data;
                });
            }
            $scope.Select_DEVICES_ByDID = function (uid_DID) {
                localStorage.setItem("url", "http://io.mayaviport.com:8080" + uid_DID);
                window.open('mConsole.aspx', '_blank');
            };
            $scope.DELETE_DEVICES_BY_DID = function (uid_DID) {
                $scope.DID = uid_DID;
                $scope.btnDelete_Click();
            };
            $scope.UPDATE_DEVICES_BY_DID = function (uid_DID) {
                $scope.DID = uid_DID;
            };
            $scope.btnSelect_Click = function () {
                var post = $http({
                    method: "POST",
                    url: "DEVICES.asmx/Get_DEVICES_Details_by_DID",
                    dataType: 'json',
                    data: { 'DID': $scope.DID },
                    headers: { "Content-Type": "application/json" }
                });
                post.success(function (data, status) {
                    $scope.BANDWIDTH = data.d.BANDWIDTH;
                    $scope.CONNECTINGTIME = data.d.CONNECTINGTIME;
                    $scope.CONNECTION_STATUS = data.d.CONNECTION_STATUS;
                    $scope.DEVICE_ID = data.d.DEVICE_ID;
                    $scope.DEVICE_KYE = data.d.DEVICE_KYE;
                    $scope.DEVICE_NAME = data.d.DEVICE_NAME;
                    $scope.DEVICE_NAME_2 = data.d.DEVICE_NAME_2;
                    $scope.DID = data.d.DID;
                    $scope.HOST_NAME = data.d.HOST_NAME;
                    $scope.TXRX_LIMIT = data.d.TXRX_LIMIT;
                    $scope.UID = data.d.UID;
                });
                post.error(function (data, status) {
                    $window.alert(data.Message);
                });
            }
            $scope.btnInsert_Click = function () {
                var post = $http({
                    method: "POST",
                    url: "UserDetails_ws.asmx/InsertDevices",
                    dataType: 'json',
                    data: { 'UID': $scope.UID, 'DEVICE_NAME': $scope.DEVICE_NAME },
                    headers: { "Content-Type": "application/json" }
                });
                post.success(function (data, status) {
                    $window.alert(data.d);
                    LoadData();
                });
                post.error(function (data, status) {
                    $window.alert(data.Message);
                });
            }
            $scope.btnUpdate_Click = function () {
                var post = $http({
                    method: "POST",
                    url: "UserDetails_ws.asmx/UpdateDevices",
                    dataType: 'json',
                    data: { 'DID': $scope.DID, 'DEVICE_NAME': $scope.DEVICE_NAME },
                    headers: { "Content-Type": "application/json" }
                });
                post.success(function (data, status) {
                    $window.alert(data.d);
                    LoadData();
                });
                post.error(function (data, status) {
                    $window.alert(data.Message);
                });
            }
            $scope.btnDelete_Click = function () {
                var post = $http({
                    method: "POST",
                    url: "UserDetails_ws.asmx/DeleteDevices",
                    dataType: 'json',
                    data: { 'DID': $scope.DID },
                    headers: { "Content-Type": "application/json" }
                });
                post.success(function (data, status) {
                    $window.alert(data.d);
                    LoadData();
                });
                post.error(function (data, status) {
                    $window.alert(data.Message);
                });
            }
        });
	</script>
</asp:Content>

