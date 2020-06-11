﻿<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head>
    <meta charset="utf-8" /> <!-- utf-8 works for most cases -->
    <meta name="viewport" content="width=device-width" /> <!-- Forcing initial-scale shouldn't be necessary -->
    <meta http-equiv="X-UA-Compatible" content="IE=edge" /> <!-- Use the latest (edge) version of IE rendering engine -->
    <title>API Test Page</title> <!-- The title tag shows in email notifications, like Android 4.4. -->
    <script src="//ajax.googleapis.com/ajax/libs/jquery/2.1.1/jquery.min.js"></script>

    <style type="text/css">
        .style1 {
            width: 200px;
            height: 68px;
        }

        html,
        body {
            Margin: 0 !important;
            padding: 0 !important;
            height: 100% !important;
            width: 100% !important;
        }

        /* What it does: Stops email clients resizing small text. */
        * {
            -ms-text-size-adjust: 100%;
            -webkit-text-size-adjust: 100%;
        }

        /* What it does: Forces Outlook.com to display emails full width. */
        .ExternalClass {
            width: 100%;
        }

        /* What is does: Centers email on Android 4.4 */
        div[style*="margin: 16px 0"] {
            margin: 0 !important;
        }

        /* What it does: Stops Outlook from adding extra spacing to tables. */
        table,
        td {
            mso-table-lspace: 0pt !important;
            mso-table-rspace: 0pt !important;
        }

        /* What it does: Fixes webkit padding issue. Fix for Yahoo mail table alignment bug. Applies table-layout to the first 2 tables then removes for anything nested deeper. */
        table {
            border-spacing: 0 !important;
            border-collapse: collapse !important;
            table-layout: fixed !important;
            Margin: 0 auto !important;
        }

            table table table {
                table-layout: auto;
            }

        /* What it does: Uses a better rendering method when resizing images in IE. */
        img {
            -ms-interpolation-mode: bicubic;
        }

        /* What it does: Overrides styles added when Yahoo's auto-senses a link. */
        .yshortcuts a {
            border-bottom: none !important;
        }

        /* What it does: A work-around for iOS meddling in triggered links. */
        .mobile-link--footer a,
        a[x-apple-data-detectors] {
            color: inherit !important;
            text-decoration: underline !important;
        }
    </style>
    <!-- Progressive Enhancements -->
    <style>
        body, table, tbody, tr, td {
            font-family: Arial;
            font-size: large;
            background-color: #ffffff;
        }

        h2 {
            text-align: center;
        }
    </style>
    <script type="text/javascript">
        $(document).ready(function () {
            $('#btnUploadFile').on('click', function () {
                debugger;
                var data = new FormData();
                var files = $("#fileUpload").get(0).files;

                if (files.length > 0) {
                    data.append("UploadContract", files[0]);                  
                    data.append("DocumentTitle", "testing");
                    data.append("CampaignId", 1);
                    data.append("Type", 1);
                    data.append("SubTypeId", 2);                 
                }
                var ajaxRequest = $.ajax({
                    type: "POST",
                    url: "campaign/UploadCampaignMultimedia",
                    contentType: false,
                    processData: false,
                    data: data
                });
            });
            });
    </script>
</head>
<body>
    <table style="border-collapse: collapse;" border="0" width="100%" cellspacing="0" cellpadding="0" bgcolor="#ecf0f1">
        <tbody>
            <tr>
                <td valign="top">
                    <center style="width: 100%;">
                        <div style="font-size: 1px; line-height: 1px; max-height: 0px; max-width: 0px; opacity: 0; overflow: hidden; mso-hide: all; font-family: sans-serif;">[[SUBJECT]]</div>
                        <div style="max-width: 600px;">
                            <table style="max-width: 600px;" border="0" width="100%" cellspacing="0" cellpadding="0" align="center">
                                <tbody>
                                    <tr></tr>
                                </tbody>
                            </table>
                            <table style="max-width: 600px;" border="0" width="100%" cellspacing="0" cellpadding="0" align="center">
                                <tbody>
                                    <tr>
                                        <td>
                                            <h2 style="text-wrap:normal">WELCOME TO API TEST PAGE</h2>
                                        </td>
                                    </tr>

                                </tbody>
                            </table>
                        </div>
                    </center>
                </td>
            </tr>
        </tbody>
    </table>


    <br />
    <p>

        <div>
            <label for="fileUpload"></label>
            Select File to Upload: <input id="fileUpload" type="file" />

            <input id="btnUploadFile" type="button" value="Upload File" />
            <br />
            <input id="btnUploadImage" type="button" value="Upload Image Bytes" />
        </div>
    </p>
</body>
</html>