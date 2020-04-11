import React, { Component } from 'react';
import './Home_products.css';

export class Home extends Component {
    constructor(props) {
        super(props);
        this.state = {
            error: null,
            isLoaded: false,
            items: []
        };
    }

    componentDidMount() {
        fetch("/api/Home/Products")
            .then(res => res.json())
            .then(
                (result) => {
                    this.setState({
                        isLoaded: true,
                        items: result
                    });
                },
                // Note: it's important to handle errors here
                // instead of a catch() block so that we don't swallow
                // exceptions from actual bugs in components.
                (error) => {
                    this.setState({
                        isLoaded: true,
                        error
                    });
                }
            )
    }

    render() {
        const { error, isLoaded, items } = this.state;
        if (error) {
            return <div>Error: {error.message}</div>;
        } else if (!isLoaded) {
            return <div>Loading...</div>;
        } else {
            return (
                <div>
                    {items.map(item => (
                        <div id="card-wrapper" class="wrapper">
                            <div id= "product-img" class="product-img">
                                <img id="thumbnail" src={item.productImageUrl}/>
                            </div>
                            <div id="product-info" class="product-info">
                                <div id="product-text" class="product-text">
                                    <h1>{item.productName}</h1>
                                    <h2>by studio and friends</h2>
                                    <p>{item.productInformation}</p>
                                </div>
                                <div class="product-price-btn">
                                    <p><span id="price" >{item.productPrice}</span>$</p>
                                    <button type="button">Add to cart</button>
                                </div>
                            </div>
                        </div>

                    ))}
                </div>
            );
        }
    }
}