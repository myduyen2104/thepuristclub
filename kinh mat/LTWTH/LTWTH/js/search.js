document.addEventListener('DOMContentLoaded', function () {
    const searchIcon = document.querySelector('.search-icon');
    const searchOverlay = document.querySelector('.search-overlay');
    const closeSearchBtn = document.querySelector('.close-search');
    const searchInput = document.querySelector('.search-input');

    searchIcon.addEventListener('click', function (event) {
        event.stopPropagation(); // Ngăn sự kiện click lan rộng đến document
        toggleSearchOverlay();
    });

    closeSearchBtn.addEventListener('click', function () {
        hideSearchOverlay();
    });

    document.addEventListener('click', function (event) {
        const clickedElement = event.target;

        if (isSearchOverlayVisible() && !searchOverlay.contains(clickedElement) && clickedElement !== searchIcon) {
            hideSearchOverlay();
        }
    });

    function toggleSearchOverlay() {
        if (isSearchOverlayVisible()) {
            hideSearchOverlay();
        } else {
            showSearchOverlay();
        }
    }

    function showSearchOverlay() {
        searchOverlay.style.display = 'flex';
        searchOverlay.style.flexDirection = 'column';
        searchInput.focus(); // Focus vào ô tìm kiếm khi overlay được hiển thị
    }

    function hideSearchOverlay() {
        searchOverlay.style.display = 'none';
    }

    function isSearchOverlayVisible() {
        return searchOverlay.style.display === 'flex';
    }
});

fetch('https://thepuristsclub.com/products')
    .then(res => {
        return res.json()
    })
    .then(data => {
        console.log(data);
        // init
        var products = document.querySelector('.products')
        products.innerHTML = ''
        mockdata.forEach(item => {
            var newProduct = document.createElement('div')
            newProduct.classList.add('product')
            newProduct.innerHTML = `
                        <img src="${item.image}">
                        <div class="info">
                            <div class="name">${item.title}</div>
                            <div class="price">${item.price}</div>
                        </div> `;
            products.appendChild(newProduct)
        })
    });

var searchInput = document.querySelector('.search-input')
searchInput.addEventListener('input', function (e) {
    let txtSearch = e.target.value.trim().toLowerCase()
    let listProductDOM = document.querySelectorAll('.product')
    listProductDOM.forEach(item => {
        if (item.innerText.toLowerCase().includes(txtSearch)) {
            item.classList.remove('hide');
            item.classList.add('found');
        } else {
            item.classList.add('hide');
            item.classList.remove('found');
        }
    });
});