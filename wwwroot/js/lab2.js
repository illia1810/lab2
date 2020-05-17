const uri = 'api/ModelCarYears';
let modelcaryears = [];

function getModelCarYears() {
    fetch(uri)
        .then(response => response.json())
        .then(data => _displayModelCarYears(data))
        .catch(error => console.error('Unable to get models.', error));
}

function addModelCarYear() {
    const addCarTextbox = document.getElementById('add-car');
    const addYearTextbox = document.getElementById('add-year');

    const modelcaryear = {
        car: addCarTextbox.value.trim(),
        year: addYearTextbox.value.trim(),
    };

    fetch(uri, {
        method: 'POST',
        headers: {
            'Accept': 'application/json'
        },
        body: JSON.stringify(modelcaryear)
    })
        .then(response => response.json())
        .then(() => {
            getModelCarYears();
            addCarTextbox.value = '';
            addYearTextbox.value = '';

        })
        .catch(error => console.error('Unable to add models.', error));
}
function deleteModelCarYear(id) {
    fetch('${uri}/${id}', {
        method: 'DELETE'
    })
        .then(() => getModelCarYears())
        .catch(error => console.error('Unable to add models.', error));
}
function displayEditForm(id) {
    const modelcaryear = modelcaryears.find(modelcaryear => modelcaryear.id === id);

    document.getElementById('edit-id').value = modelcaryear.id;
    document.getElementById('edit-car').value = modelcaryear.car;
    document.getElementById('edit-year').value = modelcaryear.year;
    document.getElementById('editForm').style.display = 'block';
}
function updateModelCarYear() {
    const modelcaryearId = document.getElementById('edit-id').value;
    const modelcaryear = {
        id: parseInt(modelcaryearId, 10),
        name: document.getElementById('edit-car').value.trim(),
        info: document.getElementById('edit-year').value.trim()
    };
    fetch('${uri}/${modelcaryearId}', {
        method: 'PUT',
        headers: {
            'Accept': 'application/json',
            'Content-Type': 'application/json'
        },
        body: JSON.stringify(modelcaryear)
    })
        .then(() => getModelCarYears())
        .catch(error => console.error('Unable to update models.', error));
    closeInput();
    return false;
}
function closeInput() {
    document.getElementById('editForm').style.display = 'none';
}
function _displayModelCarYears(data) {
    const tBody = document.getElementById('modelcaryears');
    tBody.innerHTML = '';

    const button = document.createElement('button');

    data.forEach(modelcaryear => {
        let editButton = button.cloneNode(false);
        editButton.innerText = 'Edit';
        editButton.setAttribute('onclick', `displayEditForm(${modelcaryear.id})`);

        let deleteButton = button.cloneNode(false);
        deleteButton.innerText = 'Delete';
        deleteButton.setAttribute('onclick', `deleteModelCarYear(${modelcaryear.id})`);

        let tr = tBody.insertRow();

        let td1 = tr.insertCell(0);
        let textNode = document.createTextNode(modelcaryear.car);
        td1.appendChild(textNode);

        let td2 = tr.insertCell(1);
        let textNodeInfo = document.createTextNode(modelcaryear.year);
        td2.appendChild(textNodeInfo);

        let td3 = tr.insertCell(2);
        td3.appendChild(editButton);

        let td4 = tr.insertCell(3);
        td4.appendChild(deleteButton);
    });

    modelcaryears = data;
}