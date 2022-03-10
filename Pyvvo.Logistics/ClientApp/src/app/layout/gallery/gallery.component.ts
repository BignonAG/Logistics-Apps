import { Component, OnInit } from '@angular/core';
import {  NbDialogRef } from '@nebular/theme';
import { GalleryService } from '../../service/gallery.service';
import { Image } from '../../service/Model/image';

@Component({
  selector: 'app-gallery',
  templateUrl: './gallery.component.html',
  styleUrls: ['./gallery.component.scss']
})

export class GalleryComponent implements OnInit {
  errorMessage: string;
  uriList;
  images: Image[];
  constructor(protected dialogRef: NbDialogRef<GalleryComponent>, private _galleryService: GalleryService) { }

  ngOnInit() {
    //this.getBlobs();
    this.getMedias();
  }


  close() {
    this.dialogRef.close();
  }

  pickItem(uri: string) {
    this.dialogRef.close(uri);
  }

  getMedias() {
    return this._galleryService.getMedias().subscribe(
      images => {
        this.images = images;
      }, error => {
        console.log(error);
      });
  }

  getBlobs() {
    return this._galleryService.getBlobs().subscribe(
      result => {
        this.uriList = result;
      }, error => {
        console.log(error);
      }
    )
  }

  onFileChange(event) {
    if (event.target.files.length > 0) {
      var file = event.target.files[0];
      var ext = file.name.substring(file.name.lastIndexOf('.') + 1);

      if (ext == 'svg' || ext == 'png' || ext == 'jpeg' || ext == 'jpg') {
        var formData = new FormData();
        formData.append('file', file, file.name);
        this._galleryService.create(formData).subscribe(
          result => {
            console.log("ok");
            this.getMedias();
          }, error => {
            console.log(error);
          }
        )
      } else {
        this.errorMessage = 'Please select an svg, png, jpeg or jpg file!';
      }

    }
  }

  delete(filename: string) {
    return this._galleryService.delete(filename).subscribe( result => this.getBlobs(), error => console.log(error));
  }

}
