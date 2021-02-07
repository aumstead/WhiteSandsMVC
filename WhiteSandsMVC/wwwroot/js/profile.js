let isDrawerOpen = false;

function toggleEditDrawer(prefType) {
    if (isDrawerOpen) {
        const drawer = document.getElementById(prefType + '-prefs');
        const form = document.getElementById(prefType + '-form');
        const btn = document.getElementById(prefType + '-toggle-btn')

        drawer.classList.remove('profile-preferences__edit-drawer--show')
        form.classList.remove('profile-preferences-form--show')
        btn.classList.remove('profile-preferences__edit-btn--cancel');
        btn.innerText = "Edit"

        isDrawerOpen = false;
    } else {
        const drawer = document.getElementById(prefType + '-prefs');
        const form = document.getElementById(prefType + '-form');
        const btn = document.getElementById(prefType + '-toggle-btn')

        drawer.classList.add('profile-preferences__edit-drawer--show');
        form.classList.add('profile-preferences-form--show')
        btn.classList.add('profile-preferences__edit-btn--cancel');
        btn.innerText = "Cancel"

        isDrawerOpen = true;
    }
}

function handleClick(userId, interestId, type) {
    const btnEl = document.getElementById(`${type}-${interestId}`)
    const errorDiv = document.getElementById(`${type}-error`)
    errorDiv.classList.remove('profile-interests__error--show')

    if (btnEl.classList.contains('profile-interests__btn--subscribed')) {
        const method = 'DELETE'
        const url = `/api/profile/?userId=${userId}&interestId=${interestId}&type=${type}`;
        fetch(url, {
            method: method
        })
            .then(response => {
                if (response.status !== 200) {
                    throw new Error(`Status code ${response.status}: internal error.`)
                }
            })
            .then(() => handleBtnStyle(method, interestId, type))
            .catch(err => {
                console.log(err)
                errorDiv.classList.add('profile-interests__error--show')
            })
    } else {
        const method = 'POST'
        const url = `/api/profile/?userId=${userId}&interestId=${interestId}&type=${type}`;
        fetch(url, {
            method: method
        })
            .then(response => {
                if (response.status !== 200) {
                    throw new Error(`Status code ${response.status}: internal error.`)
                }
            })
            .then(() => handleBtnStyle(method, interestId, type))
            .catch(err => {
                console.log(err)
                errorDiv.classList.add('profile-interests__error--show')
            })
    }
}

function handleBtnStyle(methodType, interestId, type) {
    const btnEl = document.getElementById(`${type}-${interestId}`)
    if (methodType === 'POST') {
        btnEl.classList.add('profile-interests__btn--subscribed')
    } else if (methodType === 'DELETE') {
        btnEl.classList.remove('profile-interests__btn--subscribed')
    } else {
        console.error('Error handling button style')
    }
}