import React, { Component } from 'react';
import './Home_products.css';

export class Home extends Component {
    constructor(props) {
        super(props);
        this.state = {
            error: null,
            isLoaded: false,
            items: {}
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
                <div className="row">
                    {items.map(item => (
                        <div id="card-wrapper" className="cwrapper">

                            <div id="cproduct-img" className="cproduct-img">
                                <img id="thumbnail" src={item.productImageUrl} />
                            </div>

                            <div id="product-info" className="product-info">
                                <div id="product-text" className="product-text">
                                    <h1><b>{item.productName}</b></h1>
                                    <h2>imported by knn inc</h2>
                                    <p>{item.productInformation}</p>
                                </div>
                                <div className="product-price-btn">
                                    <p><span id="price" >${item.productPrice}</span></p>
                                    <button onClick={() => this.props.addToCart(JSON.stringify(item))} type="button">Add to cart</button>
                                </div>
                            </div>

                        </div>

                    ))}
                </div>
            );
        }
    }
}