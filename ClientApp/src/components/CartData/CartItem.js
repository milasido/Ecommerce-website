import React from 'react';
import { Link } from 'react-router-dom';

export default function CartItem({ carts, handleRemoveItem, handleIncrease, handleDecrease }) {
   
    return (
        <div>
        {
            carts.map(item => (
                <div className="row my-2 text-capitalize text-center">

                    <div className="col-10 mx-auto col-lg-2">
                        <img
                            src={item.productImageUrl}
                            alt="Product"
                            style={{ width: '5rem', height: 'auto' }}
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
                            <span onClick={() => handleDecrease(item)} className="btn btn-black mx-1" >
                                -
                            </span>
                            <span className="btn btn-black mx-1" style={{ cursor: 'auto' }}>
                                {item.quantity}
                            </span>
                            <span onClick={() => handleIncrease(item)} className="btn btn-black mx-1" >
                                +
                            </span>
                            {/*<span className="d-lg-none">Quantity: </span> {item.quantity}*/}
                        </div>
                    </div>
                    <div className="col-10 mx-auto col-lg-2">
                        <Link
                            to="/cart"
                            className="cart-icon"
                            onClick={()=> handleRemoveItem(item)} 
                        >
                            <i className="fas fa-trash" />
                        </Link>
                    </div>
                    <div className="col-10 mx-auto col-lg-2">
                        <strong className="d-lg-none">Item total: </strong>
                        <strong>$ {item.productPrice * item.quantity}</strong>
                    </div>
                </div>))
            }
        </div>
    );
}