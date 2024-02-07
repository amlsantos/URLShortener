using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Persistence.Migrations
{
    /// <inheritdoc />
    public partial class v3 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[,]
                {
                    { new Guid("04251651-10d2-4032-aa35-d23427b73379"), 0, "a7fb37a1-8605-46b5-8573-fa6df67e288d", "Gregory24@gmail.com", false, false, null, "gregory24@gmail.com", "GREGORY20", "AQAAAAIAAYagAAAAEJMt/8FJpJKTV4/g4GkHExVtcJOOeyYshXiFPKpmGI8/Or9RS7oo/Wdwrgc5W98WSg==", "265-433-6338", false, null, true, "Gregory20" },
                    { new Guid("067d5760-6870-43e4-a70a-1919328b6c3d"), 0, "ea43bc44-97fa-4df5-803e-f90caca59742", "Barbara_Wilkinson@gmail.com", false, false, null, "barbara_wilkinson@gmail.com", "BARBARA_WILKINSON71", "AQAAAAIAAYagAAAAECWVHDOSHN1njWME06R/5J08EVfQk8P6giGGkhW8q98zQh1VQgpwVfxEMv6k4+mbMA==", "573.337.8260 x2525", true, null, true, "Barbara_Wilkinson71" },
                    { new Guid("0aa1978e-4735-4ea0-95d1-9076202fb78e"), 0, "d503e874-0121-4659-8107-ffa481a4acea", "Lena.Hettinger9@gmail.com", true, false, null, "lena.hettinger9@gmail.com", "LENA44", "AQAAAAIAAYagAAAAEPI/tUtqRt7LOA3AfTqXY0G+o3UJn4SrNVbgWKZMipD+1NMHFqwtQ2Ihx8bHcxF1tQ==", "(203) 467-0180", true, null, true, "Lena44" },
                    { new Guid("1b99dab5-4c19-47fa-9134-2909fe275bd1"), 0, "1fa64d3d-df73-4dcf-82b6-5c2e6ae7747a", "Jessie54@hotmail.com", false, false, null, "jessie54@hotmail.com", "JESSIE.BRAKUS12", "AQAAAAIAAYagAAAAEPt0hU7EvAby5g5ZrTunhJuXkTHL5DGBF7EHy293QD2lPtRRP7s+WMt7C2biTQFK3g==", "258.805.2604", true, null, false, "Jessie.Brakus12" },
                    { new Guid("1d15aad6-28fc-42bc-9ace-1267eb399dab"), 0, "96b3a62d-4e87-49f1-a5aa-f9fac360a5d9", "Kristi.Satterfield@yahoo.com", false, false, null, "kristi.satterfield@yahoo.com", "KRISTI76", "AQAAAAIAAYagAAAAEL4nX6K1GKo64zbg/kCAYd2idEIZMfA2wBTiBFKiYZlZiFV3l174VCAo7uMoWmH33g==", "494.831.8799", false, null, false, "Kristi76" },
                    { new Guid("1feba27c-e47e-4a40-af0a-7d403bd86831"), 0, "26d7c768-056a-44e9-93e8-4770b5b3b77b", "Sally_Roberts@yahoo.com", false, false, null, "sally_roberts@yahoo.com", "SALLY5", "AQAAAAIAAYagAAAAEMuZGivLi0GDHZ20EkrAMWtoBCrJR/xPZ/H2sKmSePiQxCW+XpNMZ0/HGkU8izNiyQ==", "962-420-9034 x8288", false, null, true, "Sally5" },
                    { new Guid("20d382b5-112e-4dc4-9d01-4002aa99bd82"), 0, "a6767f69-db77-4367-b278-29be0d405ce1", "Jacquelyn_Price64@hotmail.com", true, false, null, "jacquelyn_price64@hotmail.com", "JACQUELYN_PRICE", "AQAAAAIAAYagAAAAEL42LSsItAQ8bOuU3+gLzW9qYGZZXAIpylyptz7IAx8ZI/xTVFUPkbulBFgxJcomQA==", "268.207.4767", false, null, false, "Jacquelyn_Price" },
                    { new Guid("216de5f7-d870-4322-889e-d76ccfeb704e"), 0, "e912a5e4-677a-428c-8eb4-9757fdd21f6b", "Javier30@gmail.com", false, false, null, "javier30@gmail.com", "JAVIER_ALTENWERTH30", "AQAAAAIAAYagAAAAECOYCTcgGBSmJcGlprae9sLqeXt4VeFygm38KKszWUtsmaWTELznpCUui97clzU5rQ==", "(484) 459-3709 x777", false, null, false, "Javier_Altenwerth30" },
                    { new Guid("29f73729-e11a-4aac-b394-579f26079d99"), 0, "3e63c8b6-2e18-4e50-b518-40f0866fa380", "Marvin75@yahoo.com", false, false, null, "marvin75@yahoo.com", "MARVIN_LEBSACK", "AQAAAAIAAYagAAAAECDDQ3ZOiqU2KFnFNAPT3Rn0afWVcBLGN07ygCWyg7OL5hfQ2Khq4jJ/09J5oIgt+g==", "344-229-3559 x5831", true, null, false, "Marvin_Lebsack" },
                    { new Guid("2c305e0a-686c-48b5-bce2-e90c75453244"), 0, "10d23b73-3827-4f41-a1cd-9d560a18e70a", "Yvonne60@gmail.com", false, false, null, "yvonne60@gmail.com", "YVONNE.FARRELL26", "AQAAAAIAAYagAAAAEBqy4ulF8qz+lSonWvp5z+aJfbF+kxVW+c4EkgfhOhn7alikrG9w3zaJ8gGsGATI8Q==", "376.680.7062 x7955", false, null, false, "Yvonne.Farrell26" },
                    { new Guid("2c96d7f9-dd29-4d18-9699-c83d7635f095"), 0, "212b1b79-edf7-4bed-a0fb-823c5e4f7a2e", "Julian_Satterfield45@gmail.com", true, false, null, "julian_satterfield45@gmail.com", "JULIAN21", "AQAAAAIAAYagAAAAEEwobOkfwPZekagfVDq++pYA5h1zMIPM5QJxlcahi9noPRH3zfJ0NlufpvOxPaHo3g==", "(662) 649-0842", false, null, false, "Julian21" },
                    { new Guid("2f42088a-4ce4-4571-81fd-da89d01d526d"), 0, "dc2c7468-f2fd-4979-8233-520f0cfb6675", "Dawn.Wisoky@hotmail.com", true, false, null, "dawn.wisoky@hotmail.com", "DAWN80", "AQAAAAIAAYagAAAAEK4jDmyhnhLQ/5pG6xymAKARnD1qNmwA/B36Wy3sg9mwkOF6+Ht4RBp1uTIgnc9fJQ==", "(247) 770-2215", false, null, true, "Dawn80" },
                    { new Guid("35300806-43fa-4d03-bb8f-6c2ef525de8a"), 0, "1e7eb083-a5e4-49bb-8686-9ae37d0f6635", "Myra51@hotmail.com", true, false, null, "myra51@hotmail.com", "MYRA81", "AQAAAAIAAYagAAAAEM9HuYdV+VgW4gnk1uYgsSmHKubxuCxznQAPM2desgvheTbCZUai9awDgWyQjOrTMQ==", "627-664-3512 x16494", false, null, false, "Myra81" },
                    { new Guid("36eb7772-c3fe-4522-a66c-ae1d2801a613"), 0, "224b0af1-1858-422a-87d7-5ab1f9fbc381", "Jose.Champlin23@gmail.com", false, false, null, "jose.champlin23@gmail.com", "JOSE.CHAMPLIN", "AQAAAAIAAYagAAAAEPfq8g/oMKw2a4i2klcWxPOu4JqjvIruscSzajtS4x8lbkiZom3htb2TY211xeZuBQ==", "(342) 672-6050 x9503", true, null, false, "Jose.Champlin" },
                    { new Guid("4eb4073a-0608-4959-9fcf-166c8d411fd3"), 0, "535bcd2f-48d8-4a93-beef-2f237da0d497", "Gail_Kunde25@gmail.com", false, false, null, "gail_kunde25@gmail.com", "GAIL_KUNDE", "AQAAAAIAAYagAAAAEIMeVOGR4wErL5hB3UCmWjswUDFiUYS2OIyX47KMVdA4IJzCi2Im8bqDq7FeVLP/TA==", "599-555-3634 x896", false, null, true, "Gail_Kunde" },
                    { new Guid("5364b40a-3d12-49d9-bf39-a13eab8e62eb"), 0, "978e6a36-383a-4db4-b66e-8131369cd8fd", "Bruce_Hamill@hotmail.com", true, false, null, "bruce_hamill@hotmail.com", "BRUCE.HAMILL", "AQAAAAIAAYagAAAAEJxhlQxpoRoLCC1SbmGDOkYlkTdenpz0z6W95OZZ1XMFwVj2DoMmPwVW0DB0PxvmLw==", "1-325-378-2827", false, null, false, "Bruce.Hamill" },
                    { new Guid("5d8bf67d-3ef3-4d1f-a7e5-31e5c6cffc46"), 0, "7c448c1f-22ba-4ff5-952d-09459f43da7d", "Larry.Olson49@gmail.com", false, false, null, "larry.olson49@gmail.com", "LARRY84", "AQAAAAIAAYagAAAAEPv7WaANiwa5F3XF+pDpepv3IMYMieHEMcYUoKN9vbVTxgnrBtDQczuowcDqIje0FQ==", "724.496.2761 x5091", false, null, false, "Larry84" },
                    { new Guid("621a0a9d-e846-4bd9-b8ad-24d7769b3b1f"), 0, "fcf8ac1a-856d-4170-96a4-5bdf8128b96a", "Constance44@gmail.com", true, false, null, "constance44@gmail.com", "CONSTANCE81", "AQAAAAIAAYagAAAAEOfE6sm16HlvFxWiOMc1KHYDG8LT+//1mu3aMbpYmRg8J2zMOrHM4lLI0uBXJNqKoQ==", "971.722.0140 x830", false, null, true, "Constance81" },
                    { new Guid("6936dfce-6c64-44b4-9f11-f316d8d9658d"), 0, "e7dcbf6a-e367-418f-86cc-c2fa02c5a1ed", "Todd8@hotmail.com", false, false, null, "todd8@hotmail.com", "TODD.KULAS", "AQAAAAIAAYagAAAAEJVOtt3AsnMtsx1H6StGkDTuLLISyZwm6RwesKxdzFmN8wOt+SYAnlboyotqHE0wQQ==", "1-229-452-8605", false, null, true, "Todd.Kulas" },
                    { new Guid("6b25f231-d4a4-4681-b872-5c57766ff680"), 0, "a99ed153-5bd4-480f-a8d8-a27b2c25acab", "Delores.Jast12@yahoo.com", false, false, null, "delores.jast12@yahoo.com", "DELORES_JAST", "AQAAAAIAAYagAAAAEJvLIjNhbipCwj3MckqGW1LgxZPIWZOIIsiXXnDZLTz5P/EZjdzv3IPH2qhDATow3Q==", "372-631-2109 x239", true, null, false, "Delores_Jast" },
                    { new Guid("7cb59167-d4c5-4986-87af-a127d448ed34"), 0, "96030483-517c-46fb-88d5-948a5706952d", "Alex53@hotmail.com", true, false, null, "alex53@hotmail.com", "ALEX_KLING", "AQAAAAIAAYagAAAAEPq/G/MP25cBXA4z2KmTvr2sukyYJT6vqWCa91CB4cUmNNbRGHVndrgVB9JRLs7k9Q==", "329.751.6317 x06335", true, null, false, "Alex_Kling" },
                    { new Guid("7f4144c7-ecc1-474d-82e1-ccfed60ab046"), 0, "e56c0c61-5f43-4720-b223-dae36b57a023", "Teresa.Senger75@yahoo.com", false, false, null, "teresa.senger75@yahoo.com", "TERESA60", "AQAAAAIAAYagAAAAEPnIkzaAEYHP7Ls3yxviJCjdwX0p81jo1GXi9gHGkp10F16PEyamZBvkantr5lqQRg==", "531-923-0906 x69255", false, null, true, "Teresa60" },
                    { new Guid("80bd319d-819c-444f-b710-1da94bf01b9d"), 0, "f097139e-b06f-4b7e-9cbe-807575741807", "Hope.Farrell@gmail.com", false, false, null, "hope.farrell@gmail.com", "HOPE52", "AQAAAAIAAYagAAAAENdqhkj6ZUC60b19c0hLFjyMcrobb1feDiY9Qm/00I+DDQ8F1j2rJJ5knS0pV/kQeg==", "(436) 439-4890 x93587", false, null, false, "Hope52" },
                    { new Guid("8e60fb34-99d6-431a-a998-98f2056637e5"), 0, "2db55283-7717-4386-9bd3-55f87b9673c9", "Marcia.Cummings@hotmail.com", false, false, null, "marcia.cummings@hotmail.com", "MARCIA.CUMMINGS", "AQAAAAIAAYagAAAAECCspQvKb+LPRR47rVQtMkyIxQRoLbDCZoWcgth9NkW8WeKiLsU5K8jKmr0fzkgBBg==", "1-844-290-6181 x0660", false, null, false, "Marcia.Cummings" },
                    { new Guid("93d1e03d-40a6-40f7-91ae-99b28771298d"), 0, "be0577db-05a4-4e8f-9aa5-dc53e97e715c", "Amos34@gmail.com", true, false, null, "amos34@gmail.com", "AMOS_ONDRICKA13", "AQAAAAIAAYagAAAAEB4Th9BlnBldG/XAcCM+47SgXfOOPr4LX6Dfo96GEwRpN39gKoCtrgplOGu0lXTxfw==", "1-775-880-4120", true, null, true, "Amos_Ondricka13" },
                    { new Guid("98376387-6597-49f2-a3cc-2e5c9167a3c3"), 0, "ce5c496a-3c2a-415b-b420-6f32ecff4abd", "Alan27@gmail.com", true, false, null, "alan27@gmail.com", "ALAN.WINDLER41", "AQAAAAIAAYagAAAAEED0FKHHM9ytW7QSmOsBYMym1k22IpfqyEX5GBhLTDdbhzpy4VteMIbt+xP/17k86w==", "953.646.4029 x20727", true, null, false, "Alan.Windler41" },
                    { new Guid("9c72d2d6-1dda-44df-9607-929734201210"), 0, "63b57d0e-e888-4b62-8311-8a6c89850cd2", "Salvatore_Runte@yahoo.com", true, false, null, "salvatore_runte@yahoo.com", "SALVATORE50", "AQAAAAIAAYagAAAAEGXuBy9RN1Taz+iy9NWRohNS6xvyEJGiC+yMacDlnLbZsV2aXHDJgbCxHbU5HvFdXQ==", "(318) 233-1973 x2285", true, null, true, "Salvatore50" },
                    { new Guid("adc4fa42-6529-4b55-95c1-6f548b1bc90b"), 0, "aa7fa545-2a21-4337-86f2-7b4f7180c2da", "Lawrence_Breitenberg93@hotmail.com", true, false, null, "lawrence_breitenberg93@hotmail.com", "LAWRENCE53", "AQAAAAIAAYagAAAAEDcU5YlSs+cQ+p0LgWGykebTfegD6Lb9vTGKi6/XiXrzUR4tw91/ic73jsJANPaDxg==", "743.968.5873", true, null, false, "Lawrence53" },
                    { new Guid("b054ff81-3080-4dd2-9574-d8f1839231a4"), 0, "5d300281-5d3e-4d53-ac5e-44ec948f3269", "Gregory.Veum75@gmail.com", true, false, null, "gregory.veum75@gmail.com", "GREGORY.VEUM", "AQAAAAIAAYagAAAAEIQDSxB5iTjnCBuk4UcPXi1PZuIK2Mzu4ywV/yLgi5wEV+N7jtCHLLXqN1reTJHv0A==", "599-735-5443", false, null, true, "Gregory.Veum" },
                    { new Guid("b519017e-f722-4272-9a16-3be1348800d3"), 0, "d547da36-5a6c-4b38-b67e-a28f9190b5e2", "Rose31@yahoo.com", true, false, null, "rose31@yahoo.com", "ROSE.PROHASKA", "AQAAAAIAAYagAAAAELnQFBBIpJBmk5KjaXwW1BMb1nfkuZSV64RjuPfkuqgVtBaNLAML5pxNcbydt90bTQ==", "236-718-9551", true, null, false, "Rose.Prohaska" },
                    { new Guid("b6961019-a5b0-43de-966a-9206189bd39d"), 0, "f56d69da-6462-47e9-8a6d-4fdefd427134", "Darrel81@gmail.com", true, false, null, "darrel81@gmail.com", "DARREL72", "AQAAAAIAAYagAAAAEHMgxWYuvfS/dzgz4pCZiXk7EpqE1VZwWyo8AA/4qqVuv5tsFVJWiMktfhOv3cacZw==", "(259) 210-9100 x196", false, null, false, "Darrel72" },
                    { new Guid("c769fbaa-89cf-445d-83f4-870429fe4ae4"), 0, "ece92080-dd11-450e-84f1-f33e3c05e9ad", "Estelle.Nolan82@yahoo.com", false, false, null, "estelle.nolan82@yahoo.com", "ESTELLE_NOLAN6", "AQAAAAIAAYagAAAAEPloKqBvN2TeH21T7hoyTbRA9UJTVm6Npdi02J7LWQeiEPmY8TmMg+VUoujYHZOhJw==", "(786) 466-3356 x4791", false, null, true, "Estelle_Nolan6" },
                    { new Guid("c94de392-9d6c-4870-9ff9-0cf7effa6dfb"), 0, "24350132-22fb-49c2-90d3-72c8e66db270", "Donna_Koelpin@gmail.com", true, false, null, "donna_koelpin@gmail.com", "DONNA.KOELPIN", "AQAAAAIAAYagAAAAELSLLwqR/ZalUmXC33ti7u04jY5G5mpIfqawbtRxgFbP2JK3ACE805bUGHhOlPy9SA==", "(494) 304-2722 x2977", true, null, true, "Donna.Koelpin" },
                    { new Guid("cbe71842-8ed2-4861-a45c-8819ff037af5"), 0, "66f4f323-e7ec-4a58-88d3-52dd04b24dae", "Samantha_Ruecker@hotmail.com", false, false, null, "samantha_ruecker@hotmail.com", "SAMANTHA.RUECKER6", "AQAAAAIAAYagAAAAEKw1Vmemt3d5nnIu3ZDDWb0fi/kigYM0y8z2rQno/7QDNmDxqi5QxAtXpVnJ/R/MLA==", "211.522.1344 x2158", false, null, false, "Samantha.Ruecker6" },
                    { new Guid("d25cb5cc-54d0-4773-9938-0de9f812e50e"), 0, "9eedddbd-79a8-4641-9061-b1116fcb1a9c", "Erica42@gmail.com", false, false, null, "erica42@gmail.com", "ERICA.GLEASON72", "AQAAAAIAAYagAAAAENgo0hcbhoXVCLK7OAyi4wwBGGrjtvmw6WB2hqsSnJLAZ6rns4f8IvHyZm6ZztwR2A==", "(809) 902-1900", false, null, false, "Erica.Gleason72" },
                    { new Guid("d3869961-ffa7-418b-8d89-ca64d92a1e5c"), 0, "ce6105bf-586d-4c40-a1ee-1d2fe3de3db7", "Barry_Williamson@hotmail.com", false, false, null, "barry_williamson@hotmail.com", "BARRY19", "AQAAAAIAAYagAAAAEPtVcXLhF2TOGNyjorj2gHs26mzztK6+S+1wKhljOF7LmCoTlLE0YIK9VfjhRzhv0A==", "(804) 600-0539", false, null, true, "Barry19" },
                    { new Guid("df1f0d4f-4e36-43aa-89bc-33313f1ca451"), 0, "cbee9ae7-244d-4239-95cf-701891118de6", "Mary.Johnston28@gmail.com", true, false, null, "mary.johnston28@gmail.com", "MARY_JOHNSTON77", "AQAAAAIAAYagAAAAEHV34o61ETyrQPJ6RxK/sNI4Sf7nUSzq78muSlpOtmu0D0F52Rej4/W3vELtEEJ3fA==", "447-230-8012 x1039", false, null, true, "Mary_Johnston77" },
                    { new Guid("f02b2137-b1bb-44c0-bd3c-8d339374b3a9"), 0, "d4054a0a-f8ff-4268-b298-4e3ac021cda9", "Betty_Kreiger50@hotmail.com", true, false, null, "betty_kreiger50@hotmail.com", "BETTY_KREIGER", "AQAAAAIAAYagAAAAEBUxVRznNs1mA3u55J5yK3L1C6Wfiwnu1tz3v/qa3DxrUWFVJbtb7xG+a5h2hOvSRg==", "395-598-1507 x40470", true, null, true, "Betty_Kreiger" },
                    { new Guid("f3f68f7f-b91a-45f2-a5ea-e8b08ca00c6a"), 0, "6c3b5821-bc1b-4600-81c8-9fd00d0ff53c", "Lindsey.Rowe68@yahoo.com", false, false, null, "lindsey.rowe68@yahoo.com", "LINDSEY.ROWE", "AQAAAAIAAYagAAAAEGDksAFadUFxvCchOgYIM/WYMOWi8n5Nb98FvCe///LqWopM7blNPiHIUQu/uFGJ+g==", "821-341-2454 x953", true, null, false, "Lindsey.Rowe" },
                    { new Guid("f6715760-c102-4146-842d-93e15e559d33"), 0, "932a03c7-865f-4a81-aadf-f91fdf27375f", "Flora16@hotmail.com", true, false, null, "flora16@hotmail.com", "FLORA0", "AQAAAAIAAYagAAAAEAj/QADRwW01VKuuiLaCAmtqfcLy/y78vjHvpsSbTIWBWQDtHBTRUvorczqgsSs4lg==", "988-708-7380", false, null, false, "Flora0" },
                    { new Guid("f73a2980-0e62-410f-95a4-31ea798ccb60"), 0, "175128a2-e9b6-4fa4-a3e4-34a97abfeaba", "Amos_Brakus86@yahoo.com", false, false, null, "amos_brakus86@yahoo.com", "AMOS_BRAKUS18", "AQAAAAIAAYagAAAAEHpl1VpIAaB5gxhq2CdvPrmU4ngtWikU1g6hGWqCmpgiK69f8nrpgVHxaVlyyJTFuQ==", "1-805-392-1449", true, null, true, "Amos_Brakus18" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("04251651-10d2-4032-aa35-d23427b73379"));

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("067d5760-6870-43e4-a70a-1919328b6c3d"));

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("0aa1978e-4735-4ea0-95d1-9076202fb78e"));

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("1b99dab5-4c19-47fa-9134-2909fe275bd1"));

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("1d15aad6-28fc-42bc-9ace-1267eb399dab"));

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("1feba27c-e47e-4a40-af0a-7d403bd86831"));

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("20d382b5-112e-4dc4-9d01-4002aa99bd82"));

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("216de5f7-d870-4322-889e-d76ccfeb704e"));

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("29f73729-e11a-4aac-b394-579f26079d99"));

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("2c305e0a-686c-48b5-bce2-e90c75453244"));

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("2c96d7f9-dd29-4d18-9699-c83d7635f095"));

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("2f42088a-4ce4-4571-81fd-da89d01d526d"));

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("35300806-43fa-4d03-bb8f-6c2ef525de8a"));

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("36eb7772-c3fe-4522-a66c-ae1d2801a613"));

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("4eb4073a-0608-4959-9fcf-166c8d411fd3"));

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("5364b40a-3d12-49d9-bf39-a13eab8e62eb"));

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("5d8bf67d-3ef3-4d1f-a7e5-31e5c6cffc46"));

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("621a0a9d-e846-4bd9-b8ad-24d7769b3b1f"));

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("6936dfce-6c64-44b4-9f11-f316d8d9658d"));

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("6b25f231-d4a4-4681-b872-5c57766ff680"));

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("7cb59167-d4c5-4986-87af-a127d448ed34"));

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("7f4144c7-ecc1-474d-82e1-ccfed60ab046"));

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("80bd319d-819c-444f-b710-1da94bf01b9d"));

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("8e60fb34-99d6-431a-a998-98f2056637e5"));

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("93d1e03d-40a6-40f7-91ae-99b28771298d"));

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("98376387-6597-49f2-a3cc-2e5c9167a3c3"));

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("9c72d2d6-1dda-44df-9607-929734201210"));

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("adc4fa42-6529-4b55-95c1-6f548b1bc90b"));

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("b054ff81-3080-4dd2-9574-d8f1839231a4"));

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("b519017e-f722-4272-9a16-3be1348800d3"));

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("b6961019-a5b0-43de-966a-9206189bd39d"));

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("c769fbaa-89cf-445d-83f4-870429fe4ae4"));

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("c94de392-9d6c-4870-9ff9-0cf7effa6dfb"));

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("cbe71842-8ed2-4861-a45c-8819ff037af5"));

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("d25cb5cc-54d0-4773-9938-0de9f812e50e"));

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("d3869961-ffa7-418b-8d89-ca64d92a1e5c"));

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("df1f0d4f-4e36-43aa-89bc-33313f1ca451"));

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("f02b2137-b1bb-44c0-bd3c-8d339374b3a9"));

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("f3f68f7f-b91a-45f2-a5ea-e8b08ca00c6a"));

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("f6715760-c102-4146-842d-93e15e559d33"));

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("f73a2980-0e62-410f-95a4-31ea798ccb60"));
        }
    }
}
