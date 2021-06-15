function sum()
{
    var num1=Number(document.getElementById('num1').value);
    var num2=Number(document.getElementById('num2').value);
     document.getElementById('res').value=num1+num2;
}
function Min()
{
    var num1=Number(document.getElementById('num1').value);
    var num2=Number(document.getElementById('num2').value);
     document.getElementById('res').value=num1-num2;
}
function div()
{
    var num1=Number(document.getElementById('num1').value);
    var num2=Number(document.getElementById('num2').value);
     document.getElementById('res').value=num1/num2;
    
}
function multi()
{
    var num1=Number(document.getElementById('num1').value);
    var num2=Number(document.getElementById('num2').value);
     document.getElementById('res').value=num1*num2;
}
function TheRemainder()
{
    var num1=Number(document.getElementById('num1').value);
    var num2=Number(document.getElementById('num2').value);
     document.getElementById('res').value=num1%num2;
}
function PlusPlus()
{
    var num=Number(document.getElementById('num').value);
    document.getElementById('result').value=num++;
}
function MinMin()
{
    var num=Number(document.getElementById('num').value);
    document.getElementById('result').value=num--;
}
function Pow()
{
    var num1=Number(document.getElementById('num1').value);
    var num2=Number(document.getElementById('num2').value);
    var num;
    num=num1;
    while(num2>1)
    {
        num1=num*num1;
        num2--;
        

    }
    document.getElementById('res').value=num1;
}





function changColor(color)
{
document.getElementById('p').style.background=color;
}
function onClickFunc()
{
    alert('Hello');
}
function RePlce()
{
    var str=document.getElementById("textarea").innerHTML;

    var res=str.replace("Bye","Welcome");
    document.getElementById("textarea").innerHTML=res;

}
function SPliTT()
{
    var str="A B C D E F G";
    var n=str.split(" " , 3);
    document.getElementById("spilt").innerHTML=n;

}
function IndX()
{
    var str="Hello My Name is Marwa";
    var n=str.indexOf("M",2);
    document.getElementById("IndeXOf").innerHTML=n;

}
function CharCodeAtt()
{
    var str="Marwa";
    var n=str.charCodeAt(0);
    document.getElementById("charCodeAt").innerHTML=n;

}
function charAtt()
{
    var str="Marwa";
    var n=str.charAt(0);
    document.getElementById("charAt").innerHTML=n;

}
function Trimm()
{
    var str="    Hi!     ";
    alert(str.trim());

}
function Concat()
{
    var str1="Hi!";
    var str2="My Name's:";
    var str3="Marwa.";
    var res=str1.concat(str2,str3);
    document.getElementById("Concat").innerHTML=res;


}





