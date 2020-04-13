﻿import React from 'react';

export default function CartItem({carts}) {

    //const carts = this.props.carts;
    return (
        <div>
        {
            carts.map(item => (
                <div className="row my-2 text-capitalize text-center">

                    <div className="col-10 mx-auto col-lg-2">
                        <img
                            src={item.productImageUrl}
                            alt="Product"
                            style={{ width: '5rem', height: '5rem' }}
                            className="img-fluid"
                        />
                    </div>

                    <div className="col-10 mx-auto col-lg-2">
                        <span className="d-lg-none">Product: </span>{item.productName}

                    </div>
                    <div className="col-10 mx-auto col-lg-2">
                        <span className="d-lg-none">Price: </span>$ {item.productPrice}
                    </div>
                    <div className="col-10 mx-auto col-lg-2 my-2 my-lg-0">
                        <div className="d-flex justify-content-center">
                            <span className="btn btn-black mx-1" >
                                -
                            </span>
                            <span className="btn btn-black mx-1" style={{ cursor: 'auto' }}>

                            </span>
                            <span className="btn btn-black mx-1" >
                                +
                        </span>
                        </div>
                    </div>
                    <div className="col-10 mx-auto col-lg-2">
                        <div
                            className="cart-icon"

                        >
                            <i className="fas fa-trash" />
                        </div>
                    </div>
                    <div className="col-10 mx-auto col-lg-2">
                        <strong className="d-lg-none">Item total: </strong>
                        <strong>$</strong>
                    </div>
                </div>))
            }
        </div>
    );
}