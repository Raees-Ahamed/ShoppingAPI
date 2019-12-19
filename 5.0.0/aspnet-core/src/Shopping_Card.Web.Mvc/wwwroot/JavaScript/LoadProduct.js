function LoadProduct(id) {
    var http = new XMLHttpRequest();
    http.open("GET", "../Product/GetProductById/" + id, true);
    http.send();

    http.onreadystatechange = function () {
        if (this.readyState == 4 && this.status == 200) {
            var obj = JSON.parse(this.responseText);

             
            if (obj.result != null) {
                document.getElementById("Description").value = obj.result.description;
                document.getElementById("Price").value = obj.result.unitPrice;
            }
            else {
                document.getElementById("Description").value = "Not Found";
                document.getElementById("Price").value = "Not Found";
            }
        }
    }
}

function LoadProductEdit(orderid,id) {
    var http = new XMLHttpRequest();
    http.open("GET", "../../Product/GetProductById/" + orderid, true);
    http.send();

    http.onreadystatechange = function () {
        if (this.readyState == 4 && this.status == 200) {
            var obj = JSON.parse(this.responseText);

            if (obj.result != null) {
                if (orderid)
                {                    
                    document.getElementById("price " + id).value = obj.result.unitPrice;
                    document.getElementById("subId " + id).innerHTML = obj.result.Id;
                } else {
                    document.getElementById("price "+id).value = obj.result.unitPrice;
                }
            }
            else {
                if (id) {
                    document.getElementById("price " + id).value = obj.result.unitPrice;
                } else {
                    document.getElementById("price "+id).value = "Not Found";
                }
            }
        }
    }
}