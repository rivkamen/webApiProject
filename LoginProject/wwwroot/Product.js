


const addToBasket = (prod) => {

    console.log("addToBasket");
    const basket = JSON.parse(sessionStorage.getItem('basketArray')) || [];

    const index = basket.findIndex(item => item.productId === prod.productId);
    if (index !== -1) {
        basket[index].quantity++;
    } else {
        prod = { ...prod, quantity: 1 };
        basket.push(prod);
    }

    sessionStorage.setItem('basketArray', JSON.stringify(basket));
    updateSum(prod.price);
    updateCount();
}

// Function to remove a product from the basket
const removeFromBasket = (productId) => {
    console.log("removeFromBasket");
    const basket = JSON.parse(sessionStorage.getItem('basketArray')) || [];

    const index = basket.findIndex(item => item.productId === productId);
    if (index !== -1) {
        if (basket[index].quantity > 1) {
            basket[index].quantity--;
        } else {
            basket.splice(index, 1);
        }
        sessionStorage.setItem('basketArray', JSON.stringify(basket));

        const removedProduct = basket.find(item => item.productId === productId);
        if (removedProduct) {
            updateSum(-removedProduct.price);
        }

        updateCount(-1); // Decrease count by 1
    } else {
        console.warn('Product not found in the basket');
    }
}
let globalSum = 0;
// Function to update the count of items in the basket
const updateCount = () => {
    const currentCount = parseInt(document.getElementById('ItemsCountText').textContent) || 0;
    const newCount = currentCount + 1;
    document.getElementById('ItemsCountText').textContent = newCount;
}

// Function to update the total sum
const updateSum = (sum) => {
        const currentSum = parseFloat(document.getElementById('sum').textContent) || 0;
    console.log(currentSum);
    const newSum = currentSum + sum;
    document.getElementById('sum').textContent = newSum.toFixed(2);
    globalSum = newSum;
    sessionStorage.setItem('pay', globalSum);

}

// Function to draw products list
const drawProducts = (products) => {
    const template = document.getElementById('temp-card');
    products.forEach(product => {
        const clone = template.content.cloneNode(true);

        clone.querySelector('img').src = `../Images/${product.description.trim()}.jpg`;
        clone.querySelector('h1').textContent = product.productName;
        clone.querySelector('.price').textContent = product.price;
        clone.querySelector('.description').textContent = product.description;
        clone.querySelector('button').addEventListener('click', () => {
            addToBasket(product);
            console.log('Product added to cart:', product.description);
        });

        document.getElementById('ProductList').appendChild(clone);
    });
}

// Function to fetch all products
const getAllProduct = async () => {
    const responseGet = await fetch('api/Product');
    if (responseGet.ok) {
        const dataGet = await responseGet.json();
        console.log(dataGet);
        drawProducts(dataGet);
    }
}

// Function to draw basket items
const drawBasket = () => {
    const productsArr = JSON.parse(sessionStorage.getItem('basketArray')) || [];
    const template = document.getElementById('temp-row');

    const basketList = document.getElementById('BasketList');
    basketList.innerHTML = ''; // Clear existing items

    productsArr.forEach(product => {
        const row = template.content.cloneNode(true);
        row.querySelector(".price").innerText = product.price;
        row.querySelector(".ii").innerText = product.quantity;
        row.querySelector(".descriptionColumn").innerText = product.description;
        if (product.imageUrl) {
            row.querySelector("img").src = '../Images/' + product.imageUrl;
        }

        // Attach the remove event listener to the button
        row.querySelector('.removeButton').addEventListener('click', () => {
            removeFromBasket(product.productId);
            drawBasket();
        });

        basketList.appendChild(row);
    });
}

// Fetch and display all products initially
getAllProduct();

// Draw the basket initially
drawBasket();
updateCount(0); // Initialize the count
updateSum(0); // Initialize the sum
