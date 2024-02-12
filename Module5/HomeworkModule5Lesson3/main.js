class userResponse {
    page
    per_page
    total
    total_pages
    data
    constructor(page, per_page, total, total_pages, data) {
        this.page = page;
        this.per_page = per_page;
        this.total = total;
        this.total_pages = total_pages;

        const dataArray = [];
        data.forEach(element => {
            dataArray.push(
                new userData(
                    element.id,
                    element.email,
                    element.first_name,
                    element.last_name,
                    element.avatar))
        });

        this.data = data;
    }
}

class resourceResponse {
    page
    per_page
    total
    total_pages
    data
    constructor(page, per_page, total, total_pages, data) {
        this.page = page;
        this.perPage = per_page;
        this.total = total;
        this.totalPages = total_pages;

        const dataArray = [];
        data.forEach(element => {
            dataArray.push(
                new resourceData(
                    element.id,
                    element.name,
                    element.year,
                    element.color,
                    element.pantone_value))
        });

        this.data = data;
    }
}

class userData {
    id
    email
    first_name
    last_name
    avatar
    constructor(id, email, first_name, last_name, avatar) {
        this.id = id;
        this.email = email;
        this.firstName = first_name;
        this.lastName = last_name;
        this.avatar = avatar;
    }
}

class resourceData {
    id
    name
    year
    color
    pantone_value
    constructor(id, name, year, color, pantone_value) {
        this.id = id;
        this.name = name;
        this.year = year;
        this.color = color;
        this.pantone_value = pantone_value;
    }
}

class Support {
    url
    text
    constructor(url, text) {
        this.url = url;
        this.text = text;
    }
}

function fetchReqresUserUsingFetch(page) {
    const reqres = "https://reqres.in/"

    fetch(`${reqres}api/users?page=${page}`)
        .then(async response => {
            const bodyObject = await response.json();
            console.log(bodyObject);
            const newUserResponse = new userResponse(
                bodyObject.page,
                bodyObject.per_page,
                bodyObject.total,
                bodyObject.total_pages,
                bodyObject.data);

                const domDataResult = [];

    newUserResponse.data.forEach(x => {
        domDataResult.push(`<img src="${x.avatar}" class="card-img-top" alt="User Avatar">
        <div class="card-body">
          <h5 class="card-title">${x.first_name} ${x.last_name}</h5>
          <a href="${x.email}" class="btn btn-primary">${x.email}</a>
        </div>`)
            });
            document.getElementById('card-1').innerHTML = `<div>${domDataResult[0]}</div>`;
            document.getElementById('card-2').innerHTML = `<div>${domDataResult[1]}</div>`;
            document.getElementById('card-3').innerHTML = `<div>${domDataResult[2]}</div>`;
            document.getElementById('card-4').innerHTML = `<div>${domDataResult[3]}</div>`;
            document.getElementById('card-5').innerHTML = `<div>${domDataResult[4]}</div>`;
            document.getElementById('card-6').innerHTML = `<div>${domDataResult[5]}</div>`;
        }); 
};

function fetchReqresResourcesUsingFetch() {
    const reqres = "https://reqres.in/"

    fetch(`${reqres}api/unknown/`)
        .then(async response => {
            const bodyObject = await response.json();
            console.log(bodyObject);
            const newUserResponse = new resourceResponse(
                bodyObject.page,
                bodyObject.per_page,
                bodyObject.total,
                bodyObject.total_pages,
                bodyObject.data);

                const domDataResult = [];

    newUserResponse.data.forEach(x => {
        domDataResult.push(`
        <div class="card-body" style="background-color:${x.color};">
          <h5 class="card-title">${x.name}</h5>
          <p class="card-text">${x.year}</p>
          <p class="card-text">${x.pantone_value}</p>
        </div>`)
            });
            document.getElementById('card-1').innerHTML = `<div>${domDataResult[0]}</div>`;
            document.getElementById('card-2').innerHTML = `<div>${domDataResult[1]}</div>`;
            document.getElementById('card-3').innerHTML = `<div>${domDataResult[2]}</div>`;
            document.getElementById('card-4').innerHTML = `<div>${domDataResult[3]}</div>`;
            document.getElementById('card-5').innerHTML = `<div>${domDataResult[4]}</div>`;
            document.getElementById('card-6').innerHTML = `<div>${domDataResult[5]}</div>`;
        }); 
};