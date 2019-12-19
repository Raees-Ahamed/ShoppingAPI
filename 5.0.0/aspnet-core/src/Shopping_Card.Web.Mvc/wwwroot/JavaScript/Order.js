var ProductId;
var Description;
var Price;
var Qty;

var Items = [];

function AddToCart() {

    var table = document.getElementById("CartTable");

    var temp = document.getElementById("ProductId");
    ProductId = temp.options[temp.selectedIndex].value;
    var ProductName = temp.options[temp.selectedIndex].textContent;
    Description = document.getElementById("Description").value;
    Price = document.getElementById("Price").value;
    Qty = document.getElementById("Quantity").value;

    var productId = document.createElement("input");
    productId.setAttribute("type", "text");
    productId.setAttribute("class", "form-control");   

    var productDescription = document.createElement("input");
    productDescription.setAttribute("type", "text");
    productDescription.setAttribute("class", "form-control");    

    var productUnitPrice = document.createElement("input");
    productUnitPrice.setAttribute("type", "text");
    productUnitPrice.setAttribute("class", "form-control");   

    var productQty = document.createElement("input");
    productQty.setAttribute("type", "number");
    productQty.setAttribute("class", "form-control");
    productQty.setAttribute("min", "0");

    var btn = document.createElement("input");
    btn.setAttribute("type", "button");
    btn.setAttribute("class", "btn btn-danger");
    btn.setAttribute("value", "Delete");

    productId.value = ProductName;
    productDescription.value = Description;
    productUnitPrice.value = Price;
    productQty.value = Qty;

    var row = table.insertRow(1);

    var cell1 = row.insertCell(0);
    var cell2 = row.insertCell(1);
    var cell3 = row.insertCell(2);
    var cell4 = row.insertCell(3);
    var cell5 = row.insertCell(4);
    var cell6 = row.insertCell(5);

    cell1.appendChild(productId);
    cell2.appendChild(productDescription);
    cell3.appendChild(productUnitPrice);
    cell4.appendChild(productQty);
    cell5.innerHTML = productUnitPrice.value * productQty.value;
    cell6.appendChild(btn);

    AddOrderLine();
}

function AddOrderLine() {
    var orderLine = {
        ProductId: 0,
        Description: null,
        Price: 0,
        Qty: 0,
        OrderId: 0,
        IsDelete: false
    };
    orderLine.ProductId = parseInt(ProductId);
    orderLine.Description = Description;
    orderLine.Price = parseInt(Price);
    orderLine.Qty = parseInt(Qty);
    orderLine.OrderId = 0;

    Items.push(orderLine);

    console.log(Items);
}

function ConfirmOrder() {

    var Customer = document.getElementById("CustomerId").value;

    var d = new Date();
    var currentDate = JSON.stringify(d);

    var orders = {
        Date: currentDate.replace(/^"(.*)"$/, '$1'),
        CustomerId: parseInt(Customer),
        OrderItems: Items
    };

    console.log(JSON.stringify(orders));

    $.ajax({
        url: 'http://localhost:21021/api/v1/Order',
        dataType: 'json',
        type: 'post',
        contentType: 'application/json',
        data: JSON.stringify(orders),
        processData: false,
        success: function (data, textStatus, jQxhr) {
            console.log(data, textStatus, jQxhr);
        },
        error: function (jqXhr, textStatus, errorThrown) {
            console.log(jqXhr, textStatus, errorThrown);
        }
    });

    location.replace("../Order/GetAllOrders");
}

function RemoveOrder(id) {
    var orderLineId = document.getElementById("orderLineId " + id).innerHTML;
    var productId = document.getElementById("subId " + id).innerHTML;
    var price = document.getElementById("price " + id).value;
    var quantity = document.getElementById("qty " + id).value;
    var orderId = document.getElementById("orderId " + id).innerHTML;

    var RemoveItems = {
        Id: parseInt(orderLineId),
        ProductId: parseInt(productId),
        Price: parseInt(price),
        Qty: parseInt(quantity),
        OrderId: parseInt(orderId),
        IsDelete: true
    };
    console.log(RemoveItems);
    Items.push(RemoveItems);
}

function SetOrder(id) {

    var orderLineId = document.getElementById("orderLineId " + id).innerHTML;
    var productId = document.getElementById("productId " + id).value;
    var price = document.getElementById("price " + id).value;
    var quantity = document.getElementById("qty " + id).value;
    var orderId = document.getElementById("tempOrderId " + id).innerHTML;

    var orderItems = {
        Id: parseInt(orderLineId),
        ProductId: parseInt(productId),
        Price: parseInt(price),
        Qty: parseInt(quantity),
        OrderId: parseInt(orderId),
        IsDelete: false
    };

    console.log(orderItems);
    Items.push(orderItems);
}

function EditOrder() {

    var d = new Date();
    var currentDate = JSON.stringify(d);

    order = {
        Id: 0,
        CustomerId: 0,
        Date: null,
        OrderItems: Items
    }

    var idvalue = document.getElementById("baseOrderId").innerHTML;
    order.Id = parseInt(idvalue);
    order.Date = currentDate.replace(/^"(.*)"$/, '$1');

    //var http2 = new XMLHttpRequest();
    //http2.open("POST", "../Order/ChangeOrder", true);
    //http2.setRequestHeader("Content-Type", "application/json");
    //http2.send(JSON.stringify(order));

    $.ajax({
        url: '../ChangeOrder',
        dataType: 'json',
        type: 'post',
        contentType: 'application/json',
        data: JSON.stringify(order),
        processData: false,
        success: function (data, textStatus, jQxhr) {
            console.log(data, textStatus, jQxhr);
        },
        error: function (jqXhr, textStatus, errorThrown) {
            console.log(jqXhr, textStatus, errorThrown);
        }
    });

    alert("Updated Successfully");
    location.replace("../GetAllOrders");
}