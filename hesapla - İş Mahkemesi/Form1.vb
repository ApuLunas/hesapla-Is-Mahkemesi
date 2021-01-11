Public Class Form1
    Public iade As Decimal
    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        End
    End Sub
    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        ClearTextBox(Me)
        LabelKararveİlam.Text = "Harç"
        LabelAlınmasıGerekli.Text = "Harç"
        LabelFazlaAlınan.Text = "Harç"
        LabelDavacıVekili.Text = "Ücret"
        LabelDavalıVekili.Text = "Ücret"
        LabelKO.Text = "Oran"
        LabelRO.Text = "Oran"
        LabelMaddiDavacı.Text = "Ücret"
        LabelMaddiDavalı.Text = "Ücret"
        LabelManeviDavacı.Text = "Ücret"
        LabelManeviDavalı.Text = "Ücret"
    End Sub
    Public Sub ClearTextBox(ByVal root As Control)
        For Each ctrl As Control In root.Controls
            ClearTextBox(ctrl)
            If TypeOf ctrl Is TextBox Then
                CType(ctrl, TextBox).Text = String.Empty
            End If
        Next ctrl
    End Sub
    Public Sub hesaplaavukat(ByVal sonuc As Decimal)
        If sonuc <= 4080 Then
            iade = sonuc
        End If
        If sonuc > 4080 And sonuc <= 27200 Then
            iade = 4080
        End If
        If sonuc > 27200 And sonuc <= 40000 Then
            iade = sonuc * 0.15
        End If
        If sonuc > 40000 And sonuc <= 90000 Then
            iade = ((sonuc - 40000) * 0.13) + 6000
        End If
        If sonuc > 90000 And sonuc <= 180000 Then
            iade = ((sonuc - 90000) * 0.095) + 12500
        End If
        If sonuc > 180000 And sonuc <= 430000 Then
            iade = ((sonuc - 180000) * 0.07) + 21050
        End If
        If sonuc > 430000 And sonuc <= 1050000 Then
            iade = ((sonuc - 430000) * 0.05) + 38550
        End If
        If sonuc > 1050000 And sonuc <= 1825000 Then
            iade = ((sonuc - 1050000) * 0.035) + 69550
        End If
        If sonuc > 1825000 And sonuc <= 3100000 Then
            iade = ((sonuc - 1825000) * 0.018) + 96675
        End If
        If sonuc > 3100000 Then
            iade = ((sonuc - 3100000) * 0.01) + 119625
        End If
    End Sub
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        If Val(IslahKıdem.Text) = 0 Then
            IslahKıdem.Text = DavaKıdem.Text
        End If
        If Val(Islahİhbar.Text) = 0 Then
            Islahİhbar.Text = Davaİhbar.Text
        End If
        If Val(IslahYıllıkİzin.Text) = 0 Then
            IslahYıllıkİzin.Text = DavaYıllıkİzin.Text
        End If
        If Val(IslahÜcret.Text) = 0 Then
            IslahÜcret.Text = DavaÜcret.Text
        End If
        If Val(IslahAGİ.Text) = 0 Then
            IslahAGİ.Text = DavaAGİ.Text
        End If
        If Val(IslahFMÜcreti.Text) = 0 Then
            IslahFMÜcreti.Text = DavaFMÜcreti.Text
        End If
        If Val(IslahHTÜcreti.Text) = 0 Then
            IslahHTÜcreti.Text = DavaHTÜcreti.Text
        End If
        If Val(IslahUBGTÜcreti.Text) = 0 Then
            IslahUBGTÜcreti.Text = DavaUBGTÜcreti.Text
        End If
        If Val(IslahMaddiTazminat.Text) = 0 Then
            IslahMaddiTazminat.Text = DavaMaddiTazminat.Text
        End If
        'Dönüştürme
        Dim sonuc As Decimal
        For Each a In Me.Controls
            If TypeOf a Is TextBox And a.tabindex < 61 Then
                If a.text = "" Then
                    a.text = "0"
                End If
                sonuc = Convert.ToDecimal(a.text)
                a.Text = sonuc.ToString("#,##0.00")
            End If
        Next
        Dim davadeger As Decimal
        Dim davakabul As Decimal
        Dim davared As Decimal
        Dim hesaplakabul As Decimal
        Dim hesaplared As Decimal
        Dim kabulmanevi As Decimal
        Dim redmanevi As Decimal
        Dim kabulmaddi As Decimal
        Dim redmaddi As Decimal
        Dim tharc As Decimal
        Dim pharc As Decimal
        Dim iharc As Decimal
        Dim bharc As Decimal
        Dim fharc As Decimal
        Dim vekildavaci As Decimal
        Dim vekildavali As Decimal
        Dim dctopmas As Decimal = 0
        Dim dltopmas As Decimal = 0
        '---------------------------------ÇEVİRİLER---------------------------------
        RedKıdem.Text = ((Convert.ToDecimal(IslahKıdem.Text) - Convert.ToDecimal(KabulKıdem.Text))).ToString("#,##0.00")
        Redİhbar.Text = ((Convert.ToDecimal(Islahİhbar.Text) - Convert.ToDecimal(Kabulİhbar.Text))).ToString("#,##0.00")
        RedYıllıkİzin.Text = ((Convert.ToDecimal(IslahYıllıkİzin.Text) - Convert.ToDecimal(KabulYıllıkİzin.Text))).ToString("#,##0.00")
        RedÜcret.Text = ((Convert.ToDecimal(IslahÜcret.Text) - Convert.ToDecimal(KabulÜcret.Text))).ToString("#,##0.00")
        RedAGİ.Text = ((Convert.ToDecimal(IslahAGİ.Text)) - Convert.ToDecimal(KabulAGİ.Text)).ToString("#,##0.00")
        RedFMÜcreti.Text = ((Convert.ToDecimal(IslahFMÜcreti.Text)) - Convert.ToDecimal(RaporFMÜcreti.Text)).ToString("#,##0.00")
        If Convert.ToDecimal(KabulFMÜcreti.Text) = 0 Then
            RedFMÜcreti.Text = IslahFMÜcreti.Text
        End If
        RedHTÜcreti.Text = ((Convert.ToDecimal(IslahHTÜcreti.Text)) - Convert.ToDecimal(RaporHTÜcreti.Text)).ToString("#,##0.00")
        If Convert.ToDecimal(KabulHTÜcreti.Text) = 0 Then
            RedHTÜcreti.Text = IslahHTÜcreti.Text
        End If
        RedUBGTÜcreti.Text = ((Convert.ToDecimal(IslahUBGTÜcreti.Text)) - Convert.ToDecimal(RaporUBGTÜcreti.Text)).ToString("#,##0.00")
        If Convert.ToDecimal(KabulUBGTÜcreti.Text) = 0 Then
            RedUBGTÜcreti.Text = IslahUBGTÜcreti.Text
        End If
        RedMaddiTazminat.Text = ((Convert.ToDecimal(IslahMaddiTazminat.Text) - Convert.ToDecimal(KabulMaddiTazminat.Text))).ToString("#,##0.00")
        RedManeviTazminat.Text = ((Convert.ToDecimal(DavaManeviTazminat.Text) - Convert.ToDecimal(KabulManeviTazminat.Text))).ToString("#,##0.00")
        Label16.Text = (Convert.ToDecimal(DavaKıdem.Text) + Convert.ToDecimal(Davaİhbar.Text) + Convert.ToDecimal(DavaYıllıkİzin.Text) + Convert.ToDecimal(DavaÜcret.Text) + Convert.ToDecimal(DavaAGİ.Text) + Convert.ToDecimal(DavaFMÜcreti.Text) + Convert.ToDecimal(DavaHTÜcreti.Text) + Convert.ToDecimal(DavaUBGTÜcreti.Text) + Convert.ToDecimal(DavaMaddiTazminat.Text) + Convert.ToDecimal(DavaManeviTazminat.Text)).ToString("#,##0.00")
        Label17.Text = (Convert.ToDecimal(RaporKıdem.Text) + Convert.ToDecimal(Raporİhbar.Text) + Convert.ToDecimal(RaporYıllıkİzin.Text) + Convert.ToDecimal(RaporÜcret.Text) + Convert.ToDecimal(RaporAGİ.Text) + Convert.ToDecimal(RaporFMÜcreti.Text) + Convert.ToDecimal(RaporHTÜcreti.Text) + Convert.ToDecimal(RaporUBGTÜcreti.Text) + Convert.ToDecimal(RaporMaddiTazminat.Text)).ToString("#,##0.00")
        Label18.Text = (Convert.ToDecimal(IslahKıdem.Text) + Convert.ToDecimal(Islahİhbar.Text) + Convert.ToDecimal(IslahYıllıkİzin.Text) + Convert.ToDecimal(IslahÜcret.Text) + Convert.ToDecimal(IslahAGİ.Text) + Convert.ToDecimal(IslahFMÜcreti.Text) + Convert.ToDecimal(IslahHTÜcreti.Text) + Convert.ToDecimal(IslahUBGTÜcreti.Text) + Convert.ToDecimal(IslahMaddiTazminat.Text) + Convert.ToDecimal(DavaManeviTazminat.Text)).ToString("#,##0.00")
        Label19.Text = (Convert.ToDecimal(KabulKıdem.Text) + Convert.ToDecimal(Kabulİhbar.Text) + Convert.ToDecimal(KabulYıllıkİzin.Text) + Convert.ToDecimal(KabulÜcret.Text) + Convert.ToDecimal(KabulAGİ.Text) + Convert.ToDecimal(KabulFMÜcreti.Text) + Convert.ToDecimal(KabulHTÜcreti.Text) + Convert.ToDecimal(KabulUBGTÜcreti.Text) + Convert.ToDecimal(KabulMaddiTazminat.Text) + Convert.ToDecimal(KabulManeviTazminat.Text)).ToString("#,##0.00")
        Label20.Text = (Convert.ToDecimal(RedKıdem.Text) + Convert.ToDecimal(Redİhbar.Text) + Convert.ToDecimal(RedYıllıkİzin.Text) + Convert.ToDecimal(RedÜcret.Text) + Convert.ToDecimal(RedAGİ.Text) + Convert.ToDecimal(RedFMÜcreti.Text) + Convert.ToDecimal(RedHTÜcreti.Text) + Convert.ToDecimal(RedUBGTÜcreti.Text) + Convert.ToDecimal(RedMaddiTazminat.Text) + Convert.ToDecimal(RedManeviTazminat.Text)).ToString("#,##0.00")
        Label35.Text = (Convert.ToDecimal(DavacıTebligat.Text) + Convert.ToDecimal(DavacıPosta.Text) + Convert.ToDecimal(DavacıBilirkişi.Text) + Convert.ToDecimal(DavacıTanık.Text) + Convert.ToDecimal(DavacıTalimat.Text) + Convert.ToDecimal(DavacıTalveBil.Text) + Convert.ToDecimal(DavacıAdliTıp.Text)).ToString("#,##0.00")
        Label36.Text = (Convert.ToDecimal(DavalıTebligat.Text) + Convert.ToDecimal(DavalıPosta.Text) + Convert.ToDecimal(DavalıBilirkişi.Text) + Convert.ToDecimal(DavalıTanık.Text) + Convert.ToDecimal(DavalıTalimat.Text) + Convert.ToDecimal(DavalıTalveBil.Text) + Convert.ToDecimal(DavalıAdliTıp.Text)).ToString("#,##0.00")
        davadeger = Convert.ToDecimal(Label18.Text)
        davakabul = Convert.ToDecimal(Label19.Text)
        davared = Convert.ToDecimal(Label20.Text)
        tharc = (davakabul / 1000) * 68.31
        pharc = Convert.ToDecimal(HarçPeşin.Text)
        iharc = Convert.ToDecimal(HarçIslah.Text)
        kabulmanevi = Convert.ToDecimal(KabulManeviTazminat.Text)
        redmanevi = Convert.ToDecimal(RedManeviTazminat.Text)
        kabulmaddi = Convert.ToDecimal(KabulMaddiTazminat.Text)
        redmaddi = Convert.ToDecimal(RedMaddiTazminat.Text)
        '----------------------------------HARÇLAR----------------------------------
        If davakabul = 0 Then
            tharc = 59.3
            LabelKararveİlam.Text = Math.Round(tharc, 2)
            If pharc + iharc > tharc Then
                LabelFazlaAlınan.Text = Math.Round((pharc + iharc) - tharc, 2)
                fharc = Convert.ToDecimal(LabelFazlaAlınan.Text)
                LabelAlınmasıGerekli.Text = "Harç"
            ElseIf pharc + iharc < tharc Then
                LabelAlınmasıGerekli.Text = Math.Round(tharc - (pharc + iharc), 2)
                bharc = Convert.ToDecimal(LabelAlınmasıGerekli.Text)
                LabelFazlaAlınan.Text = "Harç"
            End If
        End If
        If davakabul > 0 Then
            If tharc < 59.3 Then
                tharc = 59.3
            End If
            LabelKararveİlam.Text = Math.Round(tharc, 2)
            If pharc + iharc > tharc Then
                LabelFazlaAlınan.Text = Math.Round((pharc + iharc) - tharc, 2)
                fharc = Convert.ToDecimal(LabelFazlaAlınan.Text)
                LabelAlınmasıGerekli.Text = "Harç"
            ElseIf pharc + iharc < tharc Then
                LabelAlınmasıGerekli.Text = Math.Round(tharc - (pharc + iharc), 2)
                bharc = Convert.ToDecimal(LabelAlınmasıGerekli.Text)
                LabelFazlaAlınan.Text = "Harç"
            End If
        End If
        tharc = Math.Round(tharc, 2)
        '-----------------------------VEKALET ÜCRETLERİ-----------------------------
        hesaplakabul = davakabul
        hesaplared = davared
        If Val(DavaMaddiTazminat.Text) > 0 Or Val(DavaManeviTazminat.Text) > 0 Then
            hesaplakabul = davakabul - (kabulmaddi + kabulmanevi)
            hesaplared = davared - (redmaddi + redmanevi)
            If kabulmaddi >= redmaddi Then
                hesaplakabul = hesaplakabul + kabulmaddi
                hesaplared = hesaplared + redmaddi
            End If
        End If
        If Val(DavaManeviTazminat.Text) > 0 And kabulmanevi = 0 Then
            redmanevi = 4080
        End If
        If kabulmanevi <> 0 And redmanevi > kabulmanevi Then
            redmanevi = kabulmanevi
        End If
        '--------------------------ESKİ HESAPLAMA----------------------------------
        'If hesaplakabul <= 4080 Then
        'vekildavaci = hesaplakabul
        'End If
        'If hesaplared <= 4080 Then
        '   vekildavali = hesaplared
        'End If
        'If hesaplakabul > 4080 And hesaplakabul <= 27200 Then
        'vekildavaci = 4080
        'End If
        'If hesaplared > 4080 And hesaplared <= 27200 Then
        'vekildavali = 4080
        'End If
        'If hesaplakabul > 27200 And hesaplakabul <= 40000 Then
        'vekildavaci = (hesaplakabul) * 0.15
        'End If
        'If hesaplared > 27200 And hesaplared <= 40000 Then
        'vekildavali = (hesaplared) * 0.15
        'End If
        'If hesaplakabul > 40000 And hesaplakabul <= 90000 Then
        'vekildavaci = (((hesaplakabul) - 40000) * 0.13) + 6000
        'End If
        'If hesaplared > 40000 And hesaplared <= 90000 Then
        'vekildavali = (((hesaplared) - 40000) * 0.13) + 6000
        'End If
        'If hesaplakabul > 90000 And hesaplakabul <= 180000 Then
        'vekildavaci = (((hesaplakabul) - 90000) * 0.095) + 12500
        'End If
        'If hesaplared > 90000 And hesaplared <= 180000 Then
        'vekildavali = (((hesaplared) - 90000) * 0.095) + 12500
        'End If
        'If hesaplakabul > 180000 And hesaplakabul <= 430000 Then
        'vekildavaci = (((hesaplakabul) - 180000) * 0.07) + 21050
        'End If
        'If hesaplared > 180000 And hesaplared <= 430000 Then
        'vekildavali = (((hesaplared) - 180000) * 0.07) + 21050
        'End If
        'If hesaplakabul > 430000 And hesaplakabul <= 1050000 Then
        'vekildavaci = (((hesaplakabul) - 430000) * 0.05) + 38550
        'End If
        'If hesaplared > 430000 And hesaplared <= 1050000 Then
        'vekildavali = (((hesaplared) - 430000) * 0.05) + 38550
        'End If
        'If hesaplakabul > 1050000 And hesaplakabul <= 1825000 Then
        'vekildavaci = (((hesaplakabul) - 1050000) * 0.035) + 69550
        'End If
        'If hesaplared > 1050000 And hesaplared <= 1825000 Then
        'vekildavali = (((hesaplared) - 1050000) * 0.035) + 69550
        'End If
        'If hesaplakabul > 1825000 And hesaplakabul <= 3100000 Then
        'vekildavaci = (((hesaplakabul) - 1825000) * 0.018) + 96675
        'End If
        'If hesaplared > 1825000 And hesaplared <= 3100000 Then
        'vekildavali = (((hesaplared) - 1825000) * 0.018) + 96675
        'End If
        'If hesaplakabul > 3100000 Then
        'vekildavaci = (((hesaplakabul) - 3100000) * 0.01) + 119625
        'End If
        'If hesaplared > 3100000 Then
        'vekildavali = (((hesaplared) - 3100000) * 0.01) + 119625
        'End If
        Call hesaplaavukat(hesaplakabul)
        LabelDavacıVekili.Text = Math.Round(iade, 2)
        vekildavaci = iade
        Call hesaplaavukat(hesaplared)
        LabelDavalıVekili.Text = Math.Round(iade, 2)
        vekildavali = iade
        Call hesaplaavukat(kabulmanevi)
        LabelManeviDavacı.Text = Math.Round(iade, 2)
        Call hesaplaavukat(redmanevi)
        LabelManeviDavalı.Text = Math.Round(iade, 2)
        If kabulmaddi < redmaddi Then
            If kabulmaddi <> 0 And redmaddi > kabulmaddi Then
                redmaddi = kabulmaddi
            End If
            If Val(DavaMaddiTazminat.Text) > 0 And kabulmaddi = 0 And redmaddi > 4080 Then
                redmaddi = 4080
            End If
            If Val(DavaMaddiTazminat.Text) > 0 And kabulmaddi = 0 And redmaddi <= 4080 Then
                redmaddi = redmaddi
            End If
            Call hesaplaavukat(kabulmaddi)
            LabelMaddiDavacı.Text = Math.Round(iade, 2)
            Call hesaplaavukat(redmaddi)
            LabelMaddiDavalı.Text = Math.Round(iade, 2)
        End If
        '-----------------------------------ORAN------------------------------------
        If davakabul > 0 Then
            LabelRO.Text = Math.Round((davared / davadeger) * 100, 2)
            LabelKO.Text = Math.Round((1 - (davared / davadeger)) * 100, 2)
        Else
            LabelKO.Text = "0"
            LabelRO.Text = "100"
        End If
        '-----------------------------------YAZIM-----------------------------------
        '-----------------------------------HARÇ------------------------------------       
        If tharc > pharc + iharc And davakabul > 0 Then
            If pharc = 0 And iharc = 0 Then
                yazimharc.Text = "Alınması gereken " + tharc.ToString("#,##0.00") + "-TL karar ve ilam harcının davalıdan / DAVALILARDAN alınarak hazineye irat kaydına,"
            End If
            If pharc > 0 And iharc > 0 Then
                yazimharc.Text = "Alınması gereken " + tharc.ToString("#,##0.00") + "-TL karar ve ilam harcından peşin yatırılan " + pharc.ToString("#,##0.00") + "-TL harcın ve " + iharc.ToString("#,##0.00") + "-TL ıslah harcının mahsubu ile bakiye kalan " + bharc.ToString("#,##0.00") + "-TL harcın davalıdan / DAVALILARDAN alınarak hazineye irat kaydına,"
            End If
            If pharc > 0 And iharc = 0 Then
                yazimharc.Text = "Alınması gereken " + tharc.ToString("#,##0.00") + "-TL karar ve ilam harcından peşin yatırılan " + pharc.ToString("#,##0.00") + "-TL harcın mahsubu ile bakiye kalan " + bharc.ToString("#,##0.00") + "-TL harcın davalıdan / DAVALILARDAN alınarak hazineye irat kaydına,"
            End If
            If pharc = 0 And iharc > 0 Then
                yazimharc.Text = "Alınması gereken " + tharc.ToString("#,##0.00") + "-TL karar ve ilam harcından " + iharc.ToString("#,##0.00") + "-TL ıslah harcının mahsubu ile bakiye kalan " + bharc.ToString("#,##0.00") + "-TL harcın davalıdan / DAVALILARDAN alınarak hazineye irat kaydına,"
            End If
        End If
        If tharc < pharc + iharc And davakabul > 0 Then
            If pharc > 0 And iharc > 0 Then
                yazimharc.Text = "Alınması gereken " + tharc.ToString("#,##0.00") + "-TL karar ve ilam harcının, peşin yatırılan " + pharc.ToString("#,##0.00") + "-TL harçtan ve " + iharc.ToString("#,##0.00") + "-TL ıslah harcından mahsubu ile fazla yatırılan " + fharc.ToString("#,##0.00") + "-TL harcın karar kesinleştiğinde ve talep halinde davacıya iadesine,"
            End If
            If pharc > 0 And iharc = 0 Then
                yazimharc.Text = "Alınması gereken " + tharc.ToString("#,##0.00") + "-TL karar ve ilam harcının, peşin yatırılan " + pharc.ToString("#,##0.00") + "-TL harçtan mahsubu ile fazla yatırılan " + fharc.ToString("#,##0.00") + "-TL harcın karar kesinleştiğinde ve talep halinde davacıya iadesine,"
            End If
            If pharc = 0 And iharc > 0 Then
                yazimharc.Text = "Alınması gereken " + tharc.ToString("#,##0.00") + "-TL karar ve ilam harcının " + iharc.ToString("#,##0.00") + "-TL ıslah harcından mahsubu ile fazla yatırılan " + fharc.ToString("#,##0.00") + "-TL harcın karar kesinleştiğinde ve talep halinde davacıya iadesine,"
            End If
        End If
        If davakabul = 0 Then
            If pharc > 0 And iharc > 0 Then
                yazimharc.Text = "Alınması gereken 59,30-TL red harcının peşin yatırılan " + pharc.ToString("#,##0.00") + "-TL harçtan ve " + iharc.ToString("#,##0.00") + "-TL ıslah harcından mahsubu ile fazla yatırılan " + fharc.ToString("#,##0.00") + "-TL harcın karar kesinleştiğinde ve talep halinde davacıya iadesine,"
            End If
            If pharc < 59.3 And iharc = 0 Then
                yazimharc.Text = "Alınması gereken 59,30-TL red harcının, peşin yatırılan " + pharc.ToString("#,##0.00") + "-TL harçtan mahsubu ile bakiye " + bharc.ToString("#,##0.00") + "-TL harcın davacıdan alınarak hazineye irat kaydına,"
            End If
            If pharc >= 59.3 And iharc = 0 Then
                yazimharc.Text = "Alınması gereken 59,30-TL red harcının peşin yatırılan " + pharc.ToString("#,##0.00") + "-TL'sı harçtan mahsubu ile fazla yatırılan " + fharc.ToString("#,##0.00") + "-TL'sı harcın karar kesinleştiğinde ve talep halinde davacıya iadesine,"
            End If
            If pharc = 0 And iharc >= 59.3 Then
                yazimharc.Text = "Tahakkuk eden 59,30-TL red harcının peşin yatırılan " + iharc.ToString("#,##0.00") + "-TL ıslah harcından mahsubu ile fazla yatırılan " + fharc.ToString("#,##0.00") + "-TL harcın karar kesinleştiğinde ve talep halinde davacıya iadesine,"
            End If
            If pharc = 0 And iharc = 0 Then
                yazimharc.Text = "Tahakkuk eden 59,30-TL red harcının davacıdan alınarak hazineye irat kaydına,"
            End If
        End If
        If tharc = pharc + iharc Then
            yazimharc.Text = "Peşin alınan harcın mahsubu ile başkaca harç alınmasına yer olmadığına,"
        End If
        '------------------------------ARABULUCULUK---------------------------------
        If Convert.ToDecimal(ArabuluculukÜcreti.Text) = 0 Then
            yazimarabulucu.Text = "Lütfen Arabuluculuk ücretini kontrol edin"
        End If
        If Convert.ToDecimal(ArabuluculukÜcreti.Text) <> 0 And Convert.ToDecimal(LabelKO.Text) = 100 Then
            yazimarabulucu.Text = ArabuluculukÜcreti.Text + "-TL arabuluculuk ücreti için davalı / DAVALILAR hakkında harç tahsil müzekkeresi düzenlenmesine,"
        End If
        If Convert.ToDecimal(ArabuluculukÜcreti.Text) <> 0 And Convert.ToDecimal(LabelRO.Text) = 100 Then
            yazimarabulucu.Text = ArabuluculukÜcreti.Text + "-TL arabuluculuk ücreti için davacı hakkında harç tahsil müzekkeresi düzenlenmesine,"
        End If
        If Convert.ToDecimal(ArabuluculukÜcreti.Text) <> 0 And Convert.ToDecimal(LabelKO.Text) <> 0 And Convert.ToDecimal(LabelRO.Text) <> 0 Then
            yazimarabulucu.Text = ArabuluculukÜcreti.Text + "-TL arabuluculuk ücretinin tahsili için davalı / DAVALILAR hakkında " + ((Convert.ToDecimal(ArabuluculukÜcreti.Text) * Convert.ToDecimal(LabelKO.Text)) / 100).ToString("#,##0.00") + "-TL'lik, davacı hakkında " + (Convert.ToDecimal(ArabuluculukÜcreti.Text) - (Convert.ToDecimal(ArabuluculukÜcreti.Text) * Convert.ToDecimal(LabelKO.Text)) / 100).ToString("#,##0.00") + "-TL'lik harç tahsil müzekkeresi düzenlenmesine,"
        End If
        '-----------------------------------AAÜT------------------------------------
        If hesaplakabul > 0 And hesaplakabul < 4080 Then
            yazimdcvekili.Text = "Davacı davada kendini bir vekil ile temsil ettirdiğinden, karar tarihinde yürürlükte bulunan AAÜT'nin 13/2 maddesine göre hesaplanan " + Math.Round(vekildavaci, 2).ToString("#,##0.00") + "-TL vekalet ücretinin davalıdan / DAVALILARDAN alınarak davacıya verilmesine,"
        End If
        If hesaplared > 0 And hesaplared < 4080 Then
            yazimdlvekili.Text = "Davalı davada kendini bir vekil ile temsil ettirdiğinden, karar tarihinde yürürlükte bulunan AAÜT'nin 13/2 maddesine göre hesaplanan " + Math.Round(vekildavali, 2).ToString("#,##0.00") + "-TL vekalet ücretinin davacıdan alınarak davalıya / DAVALILARA verilmesine,"
        End If
        If hesaplakabul >= 4080 And hesaplakabul <= 27200 Then
            yazimdcvekili.Text = "Davacı davada kendini bir vekil ile temsil ettirdiğinden, karar tarihinde yürürlükte bulunan AAÜT'nin 13/1 maddesine göre hesaplanan 4.080,00-TL'sı maktu vekalet ücretinin davalıdan / DAVALILARDAN alınarak davacıya verilmesine,"
        End If
        If hesaplared >= 4080 And hesaplared <= 27200 Then
            yazimdlvekili.Text = "Davalı kendisini vekili vasıtasıyla temsil ettirdiğinden karar tarihinde yürürlükte bulunan AAÜT'nin 13/1 maddesine göre hesaplanan 4.080,00-TL'sı maktu vekalet ücretinin davacıdan alınarak davalıya / DAVALILARA verilmesine,"
        End If
        If hesaplakabul > 27200 Then
            yazimdcvekili.Text = "Davacı davada kendini bir vekil ile temsil ettirdiğinden, karar tarihinde yürürlükte bulunan AAÜT'sine göre hesaplanan " + Math.Round(vekildavaci, 2).ToString("#,##0.00") + "-TL nispi vekalet ücretinin davalıdan / DAVALILARDAN alınarak davacıya verilmesine,"
        End If
        If hesaplared > 27200 Then
            yazimdlvekili.Text = "Davalı davada kendini bir vekil ile temsil ettirdiğinden, karar tarihinde yürürlükte bulunan AAÜT'sine göre hesaplanan " + Math.Round(vekildavali, 2).ToString("#,##0.00") + "-TL nispi vekalet ücretinin davacıdan alınarak davalıya / DAVALILARA verilmesine,"
        End If
        If vekildavali = 0 Then
            yazimdlvekili.Text = ""
        End If
        If vekildavaci = 0 Then
            yazimdcvekili.Text = ""
        End If
        '----------------------------------MANEVİ AAÜT-----------------------------
        If kabulmanevi > 0 And kabulmanevi < 4080 Then
            manevivekaletdavacıvekili.Text = "Manevi Tazminat talebi yönünden davacı davada kendini vekil ile temsil ettirdiğinden, karar tarihinde yürürlükte bulunan AAÜT'nin 13/2 maddesine göre hesaplanan " + Math.Round(Convert.ToDecimal(LabelManeviDavacı.Text), 2).ToString("#,##0.00") + "-TL vekalet ücretinin davalıdan / DAVALILARDAN alınarak davacıya verilmesine,"
        End If
        If kabulmanevi >= 4080 And kabulmanevi <= 27200 Then
            manevivekaletdavacıvekili.Text = "Manevi Tazminat talebi yönünden davacı davada kendini vekil ile temsil ettirdiğinden, karar tarihinde yürürlükte bulunan AAÜT'nin 13/1 maddesine göre hesaplanan 4.080,00-TL'sı maktu vekalet ücretinin davalıdan / DAVALILARDAN alınarak davacıya verilmesine,"
        End If
        If kabulmanevi > 27200 Then
            manevivekaletdavacıvekili.Text = "Manevi Tazminat talebi yönünden davacı davada kendini vekil ile temsil ettirdiğinden, karar tarihinde yürürlükte bulunan AAÜT'sine göre hesaplanan " + Math.Round(Convert.ToDecimal(LabelManeviDavacı.Text), 2).ToString("#,##0.00") + "-TL vekalet ücretinin davalıdan / DAVALILARDAN alınarak davacıya verilmesine,"
        End If
        If redmanevi > 0 And redmanevi < 4080 Then
            manevivekaletdavalıvekili.Text = "Manevi Tazminat talebi yönünden davalı davada kendini vekil ile temsil ettirdiğinden, karar tarihinde yürürlükte bulunan AAÜT'nin 13/2 maddesine göre hesaplanan " + Math.Round(Convert.ToDecimal(LabelManeviDavalı.Text), 2).ToString("#,##0.00") + "-TL vekalet ücretinin davacıdan alınarak davalıya / DAVALILARA verilmesine,"
        End If
        If redmanevi >= 4080 And redmanevi <= 27200 Then
            manevivekaletdavalıvekili.Text = "Manevi Tazminat talebi yönünden davalı davada kendini vekil vasıtasıyla temsil ettirdiğinden karar tarihinde yürürlükte bulunan AAÜT'nin 13/1 maddesine göre hesaplanan 4.080,00-TL'sı maktu vekalet ücretinin davacıdan alınarak davalıya / DAVALILARA verilmesine,"
        End If
        If redmanevi > 27200 Then
            manevivekaletdavalıvekili.Text = "Manevi Tazminat talebi yönünden davalı davada kendini vekil ile temsil ettirdiğinden, karar tarihinde yürürlükte bulunan AAÜT'sine göre hesaplanan " + Math.Round(Convert.ToDecimal(LabelManeviDavalı.Text), 2).ToString("#,##0.00") + "-TL vekalet ücretinin davacıdan alınarak davalıya / DAVALILARA verilmesine,"
        End If
        If Val(RedManeviTazminat.Text) > Val(KabulManeviTazminat.Text) Then
            manevivekaletdavalıvekili.Text = "Manevi Tazminat talebi yönünden davalı davada kendini vekil ile temsil ettirdiğinden, karar tarihinde yürürlükte bulunan AAÜT'nin 10/2 maddesine göre hesaplanan " + Math.Round(Convert.ToDecimal(LabelManeviDavalı.Text), 2).ToString("#,##0.00") + "-TL vekalet ücretinin davacıdan alınarak davalıya / DAVALILARA verilmesine,"
        End If
        If kabulmanevi = 0 And redmanevi >= 4080 Then
            manevivekaletdavalıvekili.Text = "Manevi Tazminat talebi yönünden davalı davada kendini vekil ile temsil ettirdiğinden, karar tarihinde yürürlükte bulunan AAÜT'nin 10/3 maddesine göre hesaplanan 4.080,00-TL maktu vekalet ücretinin davacıdan alınarak davalıya / DAVALILARA verilmesine,"
        End If
        If kabulmanevi = 0 Then
            manevivekaletdavacıvekili.Text = ""
        End If
        If redmanevi = 0 Then
            manevivekaletdavalıvekili.Text = ""
        End If
        If Val(RedMaddiTazminat.Text) > Val(KabulMaddiTazminat.Text) Then
            If kabulmaddi > 0 And kabulmaddi < 4080 Then
                maddivekaletdavacıvekili.Text = "Maddi Tazminat talebi yönünden davacı davada kendini vekil ile temsil ettirdiğinden, karar tarihinde yürürlükte bulunan AAÜT'nin 13/2 maddesine göre hesaplanan " + Math.Round(Convert.ToDecimal(LabelMaddiDavacı.Text), 2).ToString("#,##0.00") + "-TL vekalet ücretinin davalıdan / DAVALILARDAN alınarak davacıya verilmesine,"
            End If
            If kabulmaddi >= 4080 And kabulmaddi <= 27200 Then
                maddivekaletdavacıvekili.Text = "Maddi Tazminat talebi yönünden davacı davada kendini vekil ile temsil ettirdiğinden, karar tarihinde yürürlükte bulunan AAÜT'nin 13/1 maddesine göre hesaplanan 4.080,00-TL'sı maktu vekalet ücretinin davalıdan / DAVALILARDAN alınarak davacıya verilmesine,"
            End If
            If kabulmaddi > 27200 Then
                maddivekaletdavacıvekili.Text = "Maddi Tazminat talebi yönünden davacı davada kendini vekil ile temsil ettirdiğinden, karar tarihinde yürürlükte bulunan AAÜT'sine göre hesaplanan " + Math.Round(Convert.ToDecimal(LabelMaddiDavacı.Text), 2).ToString("#,##0.00") + "-TL vekalet ücretinin davalıdan / DAVALILARDAN alınarak davacıya verilmesine,"
            End If
            'If redmaddi > 0 And redmaddi < 4080 Then
            'maddivekaletdavalıvekili.Text = "Maddi Tazminat talebi yönünden davalı davada kendini vekil ile temsil ettirdiğinden, karar tarihinde yürürlükte bulunan AAÜT'nin 13/2 maddesine göre hesaplanan " + Math.Round(Convert.ToDecimal(LabelMaddiDavalı.Text), 2).ToString("#,##0.00") + "-TL vekalet ücretinin davacıdan alınarak davalıya / DAVALILARA verilmesine,"
            'End If
            'If redmaddi >= 4080 And redmaddi <= 27200 Then
            'maddivekaletdavalıvekili.Text = "Maddi Tazminat talebi yönünden davalı davada kendini vekil ile temsil ettirdiğinden, karar tarihinde yürürlükte bulunan AAÜT'nin 13/1 maddesine göre hesaplanan 4.080,00-TL'sı maktu vekalet ücretinin davacıdan alınarak davalı / DAVALILARA verilmesine,"
            'End If
            'If redmaddi > 27200 Then
            'maddivekaletdavalıvekili.Text = "Maddi Tazminat talebi yönünden davalı davada kendini vekil ile temsil ettirdiğinden, karar tarihinde yürürlükte bulunan AAÜT'sine göre hesaplanan " + Math.Round(Convert.ToDecimal(LabelMaddiDavalı.Text), 2).ToString("#,##0.00") + "-TL vekalet ücretinin davacıdan alınarak davalıya / DAVALILARA verilmesine,"
            'End If
            maddivekaletdavalıvekili.Text = "Maddi Tazminat talebi yönünden davalı davada kendini vekil ile temsil ettirdiğinden, karar tarihinde yürürlükte bulunan AAÜT'nin 13/3 maddesine göre hesaplanan " + Math.Round(Convert.ToDecimal(LabelMaddiDavalı.Text), 2).ToString("#,##0.00") + "-TL vekalet ücretinin davacıdan alınarak davalıya / DAVALILARA verilmesine,"
            If kabulmaddi = 0 And redmaddi >= 4080 Then
                maddivekaletdavalıvekili.Text = "Maddi Tazminat talebi yönünden davalı davada kendini vekil ile temsil ettirdiğinden, karar tarihinde yürürlükte bulunan AAÜT'nin 13/4 maddesine göre hesaplanan 4.080,00-TL maktu vekalet ücretinin davacıdan alınarak davalıya / DAVALILARA verilmesine,"
            End If
            If kabulmaddi = 0 Then
                maddivekaletdavacıvekili.Text = ""
            End If
            If redmaddi = 0 Then
                maddivekaletdavalıvekili.Text = ""
            End If
        End If
        If Val(KabulMaddiTazminat.Text) >= Val(RedMaddiTazminat.Text) Then
            maddivekaletdavacıvekili.Text = ""
            maddivekaletdavalıvekili.Text = ""
        End If
        '-------------------------HARÇ MASRAFLARI-------------------------------
        If Val(LabelAlınmasıGerekli.Text) > 0 And Val(LabelKO.Text) < 100 Then
            masrafharc.Text = "Davacı tarafından yatırılan " + (pharc + iharc + (Convert.ToDecimal(HarçBaşvurma.Text))).ToString("#,##0.00") + "-TL harç giderinin davalıdan / DAVALILARDAN  alınarak davacıya verilmesine,"
        End If
        If Val(LabelFazlaAlınan.Text) > 0 Then
            masrafharc.Text = "Davacı tarafından yatırılan " + ((pharc + iharc + (Convert.ToDecimal(HarçBaşvurma.Text)) - (Convert.ToDecimal(LabelFazlaAlınan.Text)))).ToString("#,##0.00") + "-TL harç giderinin davalıdan / DAVALILARDAN  alınarak davacıya verilmesine,"
        End If
        If (pharc + iharc + Convert.ToDecimal(HarçBaşvurma.Text)) = 0 Then
            masrafharc.Text = ""
        End If
        If Val(LabelKO.Text) = 100 And Val(LabelFazlaAlınan.Text) = 0 Then
            masrafharc.Text = ""
        End If
        '----------------------YARGILAMA GİDERİ--------------------------------
        masrafdavaci.Text = "Davacı tarafından yapılan dosyada sarf ve evrakı mevcut "
        masrafdavali.Text = "Davalı tarafından yapılan dosyada sarf ve evrakı mevcut "
        If davakabul > 0 Then
            If bharc > 0 And Val(LabelKO.Text) = 100 Then
                masrafdavaci.Text = masrafdavaci.Text + (pharc + iharc + Convert.ToDecimal(HarçBaşvurma.Text)).ToString("#,##0.00") + "-TL harç gideri, "
                dctopmas = dctopmas + (pharc + iharc + Convert.ToDecimal(HarçBaşvurma.Text))
            End If
        End If
        If Val(DavacıTebligat.Text) > 0 Then
            masrafdavaci.Text = masrafdavaci.Text + DavacıTebligat.Text + "-TL tebligat gideri, "
            dctopmas = dctopmas + Convert.ToDecimal(DavacıTebligat.Text)
        End If
        If Val(DavalıTebligat.Text) > 0 Then
            masrafdavali.Text = masrafdavali.Text + DavalıTebligat.Text + "-TL tebligat gideri, "
            dltopmas = dltopmas + Convert.ToDecimal(DavalıTebligat.Text)
        End If
        If Val(DavacıPosta.Text) > 0 Then
            masrafdavaci.Text = masrafdavaci.Text + DavacıPosta.Text + "-TL posta gideri, "
            dctopmas = dctopmas + Convert.ToDecimal(DavacıPosta.Text)
        End If
        If Val(DavalıPosta.Text) > 0 Then
            masrafdavali.Text = masrafdavali.Text + DavalıPosta.Text + "-TL posta gideri, "
            dltopmas = dltopmas + Convert.ToDecimal(DavalıPosta.Text)
        End If
        If Val(DavacıBilirkişi.Text) > 0 Then
            masrafdavaci.Text = masrafdavaci.Text + DavacıBilirkişi.Text + "-TL bilirkişi gideri, "
            dctopmas = dctopmas + Convert.ToDecimal(DavacıBilirkişi.Text)
        End If
        If Val(DavalıBilirkişi.Text) > 0 Then
            masrafdavali.Text = masrafdavali.Text + DavalıBilirkişi.Text + "-TL bilirkişi gideri, "
            dltopmas = dltopmas + Convert.ToDecimal(DavalıBilirkişi.Text)
        End If
        If Val(DavacıTanık.Text) > 0 Then
            masrafdavaci.Text = masrafdavaci.Text + DavacıTanık.Text + "-TL tanık gideri, "
            dctopmas = dctopmas + Convert.ToDecimal(DavacıTanık.Text)
        End If
        If Val(DavalıTanık.Text) > 0 Then
            masrafdavali.Text = masrafdavali.Text + DavalıTanık.Text + "-TL tanık gideri, "
            dltopmas = dltopmas + Convert.ToDecimal(DavalıTanık.Text)
        End If
        If Val(DavacıTalimat.Text) > 0 Then
            masrafdavaci.Text = masrafdavaci.Text + DavacıTalimat.Text + "-TL talimat gideri, "
            dctopmas = dctopmas + Convert.ToDecimal(DavacıTalimat.Text)
        End If
        If Val(DavalıTalimat.Text) > 0 Then
            masrafdavali.Text = masrafdavali.Text + DavalıTalimat.Text + "-TL talimat gideri, "
            dltopmas = dltopmas + Convert.ToDecimal(DavalıTalimat.Text)
        End If
        If Val(DavacıTalveBil.Text) > 0 Then
            masrafdavaci.Text = masrafdavaci.Text + DavacıTalveBil.Text + "-TL talimat ve bilirkişi gideri, "
            dctopmas = dctopmas + Convert.ToDecimal(DavacıTalveBil.Text)
        End If
        If Val(DavalıTalveBil.Text) > 0 Then
            masrafdavali.Text = masrafdavali.Text + DavalıTalveBil.Text + "-TL talimat ve bilirkişi gideri, "
            dltopmas = dltopmas + Convert.ToDecimal(DavalıTalveBil.Text)
        End If
        If Val(DavacıAdliTıp.Text) > 0 Then
            masrafdavaci.Text = masrafdavaci.Text + DavacıAdliTıp.Text + "-TL Adli Tıp gideri, "
            dctopmas = dctopmas + Convert.ToDecimal(DavacıAdliTıp.Text)
        End If
        If Val(DavalıAdliTıp.Text) > 0 Then
            masrafdavali.Text = masrafdavali.Text + DavalıAdliTıp.Text + "-TL Adli Tıp gideri, "
            dltopmas = dltopmas + Convert.ToDecimal(DavalıAdliTıp.Text)
        End If
        If Val(DavacıKeşifHarcı.Text) > 0 Then
            masrafdavaci.Text = masrafdavaci.Text + DavacıKeşifHarcı.Text + "-TL keşif harcı, "
            dctopmas = dctopmas + Convert.ToDecimal(DavacıKeşifHarcı.Text)
        End If
        If Val(DavalıKeşifHarcı.Text) > 0 Then
            masrafdavali.Text = masrafdavali.Text + DavalıKeşifHarcı.Text + "-TL keşif harcı, "
            dltopmas = dltopmas + Convert.ToDecimal(DavalıKeşifHarcı.Text)
        End If
        If Val(DavacıTaksi.Text) > 0 Then
            masrafdavaci.Text = masrafdavaci.Text + DavacıTaksi.Text + "-TL taksi gideri, "
            dctopmas = dctopmas + Convert.ToDecimal(DavacıTaksi.Text)
        End If
        If Val(DavalıTaksi.Text) > 0 Then
            masrafdavali.Text = masrafdavali.Text + "-TL taksi gideri, "
            dltopmas = dltopmas + Convert.ToDecimal(DavalıTaksi.Text)
        End If
        If davakabul = 0 And dctopmas > 0 Then
            masrafdavaci.Text = "Davacının yaptığı masrafların üzerinde bırakılmasına,"
        End If
        If davared = 0 And dltopmas > 0 Then
            masrafdavali.Text = "Davalının yaptığı masrafların üzerinde bırakılmasına,"
        End If
        If davakabul > 0 And Val(LabelKO.Text) < 100 Then
            masrafdavaci.Text = masrafdavaci.Text + "olmak üzere toplam " + dctopmas.ToString("#,##0.00") + "-TL yargılama masrafının davanın %" + LabelKO.Text + " kabul oranına göre hesaplanan " + Math.Round(((dctopmas / 100) * (Convert.ToDecimal(LabelKO.Text))), 2).ToString("#,##0.00") + "-TL'sının davalıdan / DAVALILARDAN alınarak davacıya verilmesine,"
        End If
        If davared > 0 And Val(LabelRO.Text) < 100 Then
            masrafdavali.Text = masrafdavali.Text + "olmak üzere toplam " + dltopmas.ToString("#,##0.00") + "-TL yargılama masrafının davanın %" + LabelRO.Text + " red oranına göre hesaplanan " + Math.Round(((dltopmas / 100) * (Convert.ToDecimal(LabelRO.Text))), 2).ToString("#,##0.00") + "-TL'sının davacıdan alınarak davalıya / DAVALILARA verilmesine,"
        End If
        If Val(LabelKO.Text) = 100 Then
            masrafdavaci.Text = masrafdavaci.Text + "olmak üzere toplam " + dctopmas.ToString("#,##0.00") + "-TL yargılama masrafının davalıdan / DAVALILARDAN alınarak davacıya verilmesine,"
        End If
        If Val(LabelRO.Text) = 100 Then
            masrafdavali.Text = masrafdavali.Text + "olmak üzere toplam " + dltopmas.ToString("#,##0.00") + " TL yargılama masrafının davacıdan alınarak davalıya / DAVALILARA verilmesine,"
        End If
        If dctopmas = 0 Then
            masrafdavaci.Text = ""
        End If
        If dltopmas = 0 Then
            masrafdavali.Text = ""
        End If
        If dltopmas > 0 And Convert.ToDecimal(Label20.Text) = 0 And Convert.ToDecimal(Label18.Text) > Convert.ToDecimal(Label19.Text) Then
            masrafdavali.Text = "Kısmen reddin takdiri indirimden kaynaklanması nedeniyle davalı / DAVALILAR yararına yargılama gideri ve vekalet ücreti takdirine yer olmadığına,"
        End If
        masrafiade.Text = "Taraflarca yatırılan ve kullanılmayan gider ve delil avanslarının karar kesinleştiğinde talep halinde taraflara iadesine,"
        If Val(SuçÜstü.Text) > 0 Then
            yazımsuçüstü.Text = "Haksız çıkacak taraftan tahsil edilmek üzere suç üstü ödeneğinden karşılanan " + SuçÜstü.Text + "-TL yargılama masrafının tahsili için davanın kabul ve red oranına göre hesaplanan " + Math.Round((Val(SuçÜstü.Text) / 100) * Convert.ToDecimal(LabelKO.Text), 2).ToString("#,##0.00") + "-TL'sı için davalı / DAVALILAR hakkında, " + Math.Round((Val(SuçÜstü.Text) / 100) * Convert.ToDecimal(LabelRO.Text), 2).ToString("#,##0.00") + "-TL'sı için davacı hakkında harç tahil müzekkereleri düzenlenmesine,"
            If Val(LabelKO.Text) = 100 Then
                yazımsuçüstü.Text = "Haksız çıkacak taraftan tahsil edilmek üzere suç üstü ödeneğinden karşılanan yargılama masrafının tahsili için davalı / DAVALILAR hakkında " + SuçÜstü.Text + "-TL'lik harç tahsil müzekkeresi düzenlenmesine,"
            End If
            If Val(LabelRO.Text) = 100 Then
                yazımsuçüstü.Text = "Haksız çıkacak taraftan tahsil edilmek üzere suç üstü ödeneğinden karşılanan yargılama masrafının tahsili için davacı hakkında " + SuçÜstü.Text + "-TL'lik harç tahsil müzekkeresi düzenlenmesine,"
            End If
        End If
    End Sub
End Class
