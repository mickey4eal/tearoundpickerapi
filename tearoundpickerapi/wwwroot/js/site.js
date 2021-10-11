const uri = 'api/Participants';
let participants = [];

function getItems() {
    fetch(uri)
        .then(response => response.json())
        .then(data => _displayItems(data))
        .then(data => randomlySelectTeaMaker(data))
        .catch(error => console.error('Unable to get items.', error));
}

function addItem() {
    const addNameTextbox = document.getElementById('add-name');
    const addDrinkPreferenceTextbox = document.getElementById('add-drinkPreference');

    const item = {
        wantsADrink: true,
        name: addNameTextbox.value.trim(),
        drinkPreference: addDrinkPreferenceTextbox.value.trim(),
        isTeaMaker: false
    };

    fetch(uri, {
        method: 'POST',
        headers: {
            'Accept': 'application/json',
            'Content-Type': 'application/json'
        },
        body: JSON.stringify(item)
    })
        .then(response => response.json())
        .then(() => {
            getItems();
            addNameTextbox.value = '';
            addDrinkPreferenceTextbox = '';
        })
        .catch(error => console.error('Unable to add item.', error));
}

function deleteItem(id) {
    fetch(`${uri}/${id}`, {
        method: 'DELETE'
    })
        .then(() => getItems())
        .catch(error => console.error('Unable to delete item.', error));
}

function displayEditForm(id) {
    const item = participants.find(item => item.id === id);

    document.getElementById('edit-name').value = item.name;
    document.getElementById('edit-drinkPreference').value = item.drinkPreference;
    document.getElementById('edit-id').value = item.id;
    document.getElementById('edit-wantsADrink').checked = item.wantsADrink;
    document.getElementById('editForm').style.display = 'block';
}

function updateItem() {
    const itemId = document.getElementById('edit-id').value;
    const item = {
        id: parseInt(itemId, 10),
        wantsADrink: document.getElementById('edit-wantsADrink').checked,
        name: document.getElementById('edit-name').value.trim(),
        drinkPreference: document.getElementById('edit-drinkPreference').value.trim()
    };

    fetch(`${uri}/${itemId}`, {
        method: 'PUT',
        headers: {
            'Accept': 'application/json',
            'Content-Type': 'application/json'
        },
        body: JSON.stringify(item)
    })
        .then(() => getItems())
        .catch(error => console.error('Unable to update item.', error));

    closeInput();

    return false;
}

function closeInput() {
    document.getElementById('editForm').style.display = 'none';
}

function _displayCount(itemCount) {
    const name = (itemCount === 1) ? 'participant' : 'participants';

    document.getElementById('counter').innerText = `${itemCount} ${name}`;
}

function _displayItems(data) {
    const tBody = document.getElementById('participants');
    tBody.innerHTML = '';

    _displayCount(data.length);

    const button = document.createElement('button');

    data.forEach(item => {
        let wantsADrinkCheckbox = document.createElement('input');
        wantsADrinkCheckbox.type = 'checkbox';
        wantsADrinkCheckbox.disabled = true;
        wantsADrinkCheckbox.checked = item.wantsADrink;

        let editButton = button.cloneNode(false);
        editButton.innerText = 'Edit';
        editButton.setAttribute('onclick', `displayEditForm(${item.id})`);

        let deleteButton = button.cloneNode(false);
        deleteButton.innerText = 'Delete';
        deleteButton.setAttribute('onclick', `deleteItem(${item.id})`);

        let tr = tBody.insertRow();

        let td1 = tr.insertCell(0);
        td1.appendChild(wantsADrinkCheckbox);

        let td2 = tr.insertCell(1);
        let textNode = document.createTextNode(item.name);
        td2.appendChild(textNode);

        let td3 = tr.insertCell(2);
        let textNode1 = document.createTextNode(item.drinkPreference);
        td3.appendChild(textNode1);

        let td4 = tr.insertCell(3);
        td4.appendChild(editButton);

        let td5 = tr.insertCell(4);
        td5.appendChild(deleteButton);
    });

    participants = data;
}

//function getTeaMaker() {
//    const tBody = document.getElementById('teaMaker');
//    tBody.innerHTML = '';

//    randomlySelectTeaMaker(data);
//}

//function randomlySelectTeaMaker(data) {
//    drinkMaker = data;

//    //const tBody = document.getElementById('teaMaker');
//    //tBody.innerHTML = '';

//    //data.forEach(item => {
//    //    let isTeaMakerCheckbox = document.createElement('input');
//    //    isTeaMakerCheckbox.type = 'checkbox';
//    //    isTeaMakerCheckbox.disabled = true;
//    //    isTeaMakerCheckbox.checked = item.isTeaMaker;

//    //    let tr = tBody.insertRow();

//    //    let td1 = tr.insertCell(0);
//    //    td1.appendChild(isTeaMakerCheckbox);

//    //    let td2 = tr.insertCell(1);
//    //    let textNode = document.createTextNode("Test Name");//item.name
//    //    td2.appendChild(textNode);
//    //});

//    //drinkMaker = data;

//    //return false;
//}

var GetDrinkMaker = function () {
    //debugger;
    var drinkMakers = participants;
    var i;

    for (i = 0; i < drinkMakers.length; i++) {
        var drinkMaker = drinkMakers[Math.floor(Math.random() * drinkMakers.length)];
        document.getElementById('teamaker').innerText = drinkMaker.name;
    }
};