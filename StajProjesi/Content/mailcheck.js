
    function ePostaKont(eposta)
{
    var duzenli = new RegExp(/^[a-z]{1}[\d\w\.-]+@[\d\w-]{3,}\.[\w]{2, 3}(\.\w{2})?$/);

    return duzenli.test(eposta);
}

function kontrol()
{
    var giris = document.getElementById('epGiris');

    if(ePostaKont(giris.value))
        giris.style.backgroundColor = "white";
    else
        giris.style.backgroundColor = "#F0D0D0";
}
